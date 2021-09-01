using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Attribute = dnMisp.Objects.Attribute;
using dnMisp.Enums;
using dnMisp.Objects;
using dnMisp.Exceptions;
using dnMisp.Misc;
using System.IO;

namespace dnMisp
{
    public partial class MispConsumer
        : HttpRestConsumer
    {
        #region Constants
        private const string MIME_TYPE_JSON = "application/json";
        private const string HTTP_AUTH_TYPE = "Authorization";
        #endregion

        #region Private fields
        private string[] types = null;
        private string[] categories = null;
        private Dictionary<string, string> typeCatMap;
        private Dictionary<string, string[]> catTypeMap;
        #endregion

        #region Public properties
        public Tag[] Tags { get; set; }

        public static MispConsumer Current { get; private set; }
        #endregion

        #region Ctors
        protected MispConsumer(
            string baseurl,
            string authKey,
            bool initMispGlobals = false,
            int MaxConnectionsPerServer = 4) : base(MaxConnectionsPerServer)
        {
            Initialize(baseurl, authKey, initMispGlobals);
        }

        protected MispConsumer(
            Uri baseurl,
            string authKey,
            bool initMispGlobals = false,
            int MaxConnectionsPerServer = 4) : base(MaxConnectionsPerServer)
        {
            Initialize(baseurl, authKey, initMispGlobals);
        }

        public static T Create<T>(
            Uri baseUri,
            string authKey,
            bool initMispGlobals = false,
            int MaxConnectionsPerServer = 4
            ) where T : MispConsumer
        {
            T newConsumer = (T)Activator.CreateInstance(typeof(T), baseUri, authKey, initMispGlobals, MaxConnectionsPerServer);
            Current = newConsumer;

            return newConsumer;
        }

        public static T Create<T>(
            string baseurl,
            string authKey,
            bool initMispGlobals = false,
            int MaxConnectionsPerServer = 4) where T : MispConsumer
        {
            return Create<T>(new Uri(baseurl), authKey, initMispGlobals, MaxConnectionsPerServer);
        }
        #endregion

        #region Initialization
        internal void Initialize(
            string baseUri,
            string authKey,
            bool initMispGlobals = false)
        {
            Initialize(new Uri(baseUri), authKey, initMispGlobals);
        }

        internal void Initialize(
            Uri baseUri,
            string authKey,
            bool initMispGlobals = false,
            bool throwIfExcept = false)
        {
            base.Init(baseUri);

            InitHttpHeaders(authKey);
            //InitJsonSettings();

            if (initMispGlobals)
                InitMispGlobals(throwIfExcept).Wait();
        }


        //private static void InitJsonSettings()
        //{
        //    JsonConvert.DefaultSettings = () => JsonHelper.Settings;
        //}

        private void InitHttpHeaders(string authKey)
        {
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MIME_TYPE_JSON));

            DefaultRequestHeaders.Add(HTTP_AUTH_TYPE, authKey);
        }

        public async Task InitMispGlobals(bool throwIfExcept = true)
        {
            await InitMispTypes(throwIfExcept);
        }

        private async Task InitMispTags(bool throwIfExcept = true)
        {
            try
            {
                TagCollection tagData = await GetAsync<TagCollection>("/tags");
                Tags = tagData.Tags;
            }
            catch (Exception ex)
            {
                if (throwIfExcept)
                    throw ex;
            }
        }

        private async Task InitMispTypes(bool throwIfExcept = true)
        {
            try
            {
                DescribeTypes data = await GetAsync<DescribeTypes>("/attributes/describeTypes.json");

                types = data.Result.Types;
                categories = data.Result.Categories;
                typeCatMap = new Dictionary<string, string>();

                foreach (var t in data.Result.SaneDefaults)
                {
                    typeCatMap.Add(t.Key, t.Value.Value<string>("default_category"));
                }

                catTypeMap = new Dictionary<string, string[]>();

                foreach (var c in data.Result.CategoryTypeMappings)
                {
                    catTypeMap.Add(c.Key, c.Value.Values<string>().ToArray());
                }
            }
            catch (Exception ex)
            {
                if (throwIfExcept)
                    throw ex;
            }
        }
        #endregion

        public string[] GetAvailableTagNames()
        {
            SortedSet<string> tagnames = new SortedSet<string>();

            foreach (Tag t in Tags)
            {
                tagnames.Add(t.Name);
            }

            return tagnames.ToArray();
        }

        public string GetDefaultCategoryForType(string type)
        {
            if (typeCatMap.ContainsKey(type))
                return typeCatMap[type];
            else
                return null;
        }

        public string[] GetTypesForCategory(string category)
        {
            if (catTypeMap.ContainsKey(category))
                return catTypeMap[category];
            else
                return null;
        }


        public async Task<MispEvent> AddEvent(MispEvent evnt)
        {
            return (await PostAsync<MispEventResponse>("/events", new MispEventResponse(evnt))).Event;
        }

        public async Task<Dictionary<string, List<string>>> GetFullEventObjectIds(string eid, string toolFilter = "")
        {
            try
            {
                string htmlRaw = await GetAsync($"/events/viewEventAttributes/{eid}/all/");

                RegexOptions options = 
                    RegexOptions.Multiline  | 
                    RegexOptions.Singleline | 
                    RegexOptions.IgnoreCase;

                // https://regex101.com/r/tw1ESk/1/
                Regex attRgx = new Regex(@$"(<tr\s*?id\s?=\s?\""((Object)_(?'Object_Id'\d*)).*?\/tr>\s*)(<tr\s*id\s?=\s?\""((Attribute)_(?'Attribute_Id'\d*)).*?\/tr>\s*)*", options);

                // Find matches.
                MatchCollection matches = attRgx.Matches(htmlRaw);

                Dictionary<string, List<string>> objectIds = new Dictionary<string, List<string>>();

                // Report on each match.
                foreach (Match match in matches)
                {
                    List<string> attributeIds = new List<string>();
                    GroupCollection groups = match.Groups;

                    var objectId = groups["Object_Id"].Value;

                    if (groups[0].Value.IndexOf(toolFilter, StringComparison.InvariantCultureIgnoreCase) == -1)
                        continue;

                    objectIds.Add(objectId, attributeIds);

                    foreach (Capture v in groups["Attribute_Id"].Captures)
                    {
                        attributeIds.Add(v.Value);
                    }
                }
                return objectIds;
            }
            catch (WebException webException)
            {
                var res = (HttpWebResponse)webException.Response;

                if (res?.StatusCode == HttpStatusCode.NotFound)
                    throw new MispServerException("Not Found", webException);
                else
                    throw webException;
            }
        }


        public async Task<MispEvent> GetEvent(string eid)
        {
            try
            {
                return (await GetAsync<MispEventResponse>($"/events/{eid}"))?.Event;
            }
            catch (WebException webException)
            {
                var r = (HttpWebResponse)webException.Response;

                if (r?.StatusCode == HttpStatusCode.NotFound)
                    throw new MispServerException("Not Found", webException);
                else
                    throw webException;
            }
        }

        public async Task<string> PushEventToZMQ(int eventId)
        {
            return await GetAsync($"/events/pushEventToZMQ/{eventId}.json");
        }

        public async Task<string> PushEventToZMQ(MispEvent e)
        {
            return await PushEventToZMQ(e.Id);
        }

        public async Task<List<MispEvent>> SearchEvent(RestSearchQuery query)
        {
            string searchUrl = $"/events/restSearch";

            var data = await PostAsync<MispEventSearchResponse>(searchUrl, query);

            return data.Response
                .Select(v => v.Event)
                .Distinct()
                .OrderBy(v => v.Id)
                .ToList();
        }

        //public List<MispEvent> SearchEventFromTags(string tagList)
        //{
        //    string searchUrl = $"/events/restSearch/download/null/null/null/null/{tagList}".Replace(":",";");
        //    var data = Get<MispEventSearchResponse>(searchUrl);

        //    return data.Response.Select(v=> v.Event).ToList() ;
        //}

        public async Task<MispEvent[]> GetEvents()
        {
            return await GetAsync<MispEvent[]>("/events");
        }


        public async Task<MispEvent> UpdateEvent(MispEvent evnt)
        {
            return (await PostAsync<MispEventResponse>($"/events/{evnt.Id}", new MispEventResponse(evnt).ToString()))?.Event;
        }

        public async Task<List<Attribute>> GetAttributesList(string eventId, string mispfilters = "", string jsonFilter = "*")
        {
            string jsonResult = await GetAsync($"/attributes/returnAttributes/download/{eventId}/{mispfilters}");
            JObject jObj = JObject.Parse(jsonResult);

            var res = jObj.SelectTokens($"$..Attribute[{jsonFilter}]");

            return res.Select(v => v.ToObject<Attribute>()).ToList();
        }

        public async Task<List<Attribute>> GetSamplesList(string eventId)
        {
            return await GetAttributesList(
                eventId,
                mispfilters: "md5&&!filename/true",
                jsonFilter: "?(@.object_id != '0')"
                );
        }

        public async Task<List<Attribute>> GetRootAttributesList(string eventId)
        {
            return await GetAttributesList(
                eventId,
                jsonFilter: "?(@.object_id == '0')");
        }

        public async Task<MalwareSampleResponse> DownloadMalware(string md5)
        {
            return await GetAsync<MalwareSampleResponse>($"attributes/downloadSample/{md5}");
        }

        public async Task<byte[]> DownloadAttachment(string attrId)
        {
            return await GetByteArrayAsync($"attributes/downloadAttachment/download/{attrId}");
        }

        public async Task<HttpStatusCode> DeleteEvent(MispEvent @event)
        {
            return await DeleteEvent(@event.Id.ToString());
        }

        public async Task<HttpStatusCode> DeleteEvent(string eid)
        {
            return await DeleteAsync($"/events/{eid}");
        }

        public async Task<MispObjectUpload> AddMalwareConfig(string eid, MalwareConfig malwareConfig, string template_id = "96")
        {
            return await AddObject(eid, malwareConfig, template_id);
        }


        public async Task<MispObjectUpload> AddObject(string eid, MispObject mispObject, string templateId = null)
        {
            mispObject.EventId = int.Parse(eid);

            foreach (var v in mispObject.Attributes)
                v.EventId = eid;

            if (string.IsNullOrWhiteSpace(templateId))
                return await PostAsync<MispObjectUpload>($"/objects/add/{eid}", mispObject);
            else
                return await PostAsync<MispObjectUpload>($"/objects/add/{eid}/{templateId}", mispObject);
        }

        //doesn't work
        //public string GetObjects(string eid, string templateId)
        //{
        //    if (string.IsNullOrWhiteSpace(templateId))
        //        return Get($"/objects/view/{eid}");
        //    else
        //        return Get($"/objects/view/{eid}/{templateId}");
        //}
        public async Task<string> RemoveObject(string objId)
        {
            return await PostAsync($"/objects/delete/{objId}/1");
        }

        public async Task<string> AddAttribute(int eid, Attribute att)
        {
            return await AddAttribute(eid.ToString(), att);
        }

        public async Task<string> AddAttribute(string eid, Attribute att)
        {
            return await PostAsync($"/attributes/add/{eid}", att);
        }

        public async Task<MispObject> GetObject(string objectId)
        {
            return await GetAsync<MispObject>($"/objects/view/{objectId}");
        }

        public async Task<List<string>> SendAttributes(MispEvent mispEvent, List<Attribute> attributes, bool proposal = false)
        {
            List<string> responses = new List<string>();

            if (proposal)
                foreach (var attribute in attributes)
                {
                    responses.Add(await ProposalAdd(mispEvent, attribute));
                }
            else
            {
                string url = $"attributes/add/{mispEvent.GetId()}";
                responses.Add(await PostAsync(url, attributes));
            }

            return responses;
        }


        public Attribute CreateNamedAttribute(
            string eid,
            string type,
            string value,
            string category,
            bool toIDS = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            string data = "",
            bool disableCorrelation = true,
            MispObject attachToObject = null)
        {
            Attribute newAtt = new Attribute(type, category, value);
            newAtt.Comment = comment;
            newAtt.ToIDS = toIDS;
            newAtt.Distribution = distribution;
            newAtt.Data = data;
            newAtt.DisableCorrelation = disableCorrelation;
            newAtt.EventId = eid;

            if (attachToObject != null)
            {
                attachToObject.Attributes.Add(newAtt);
                return newAtt;
            }

            return newAtt;
        }

        public async Task<string> AddNamedAttribute(
            string eid,
            string type,
            string value,
            string category,
            bool toIDS = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            bool proposal = false,
            string data = "",
            bool disableCorrelation = true,
            MispObject attachToObject = null)
        {
            Attribute newAtt = CreateNamedAttribute(eid, type, value, category, toIDS, comment, distribution, data, disableCorrelation, attachToObject);

            if (proposal)
                return await ProposalAdd(eid, newAtt);
            else
                return await AddAttribute(eid, newAtt);
        }

        public async Task<string> GetIndex()
        {
            return await GetAsync($"/events/index");
        }


        public async Task<string> GetAttribute(string attId)
        {
            return await GetAsync($"/attributes/{attId}");
        }

        public async Task<string> UpdateAttribute(int attributeId, Attribute att)
        {
            return await PostAsync($"/attributes/{att.Id}", att);
        }

        public async Task<string> UpdateEvent(int eventId, MispEvent ev)
        {
            return await PostAsync($"/events/{eventId}", ev);
        }

        public async Task<string> DeleteAttribute(int attId, bool hardDelete)
        {
            if (hardDelete)
                return await GetAsync($"/attributes/delete/{attId}/1");
            else
                return await GetAsync($"/attributes/delete/{attId}");
        }

        public async Task<string> DirectCall(string url, object data)
        {
            if (data == null)
                return await GetAsync(url);
            else
                return await PostAsync(url, data);
        }

        public async Task<string> Tag(Guid uuid, string tag)
        {
            AttachTagRequest atr = new AttachTagRequest() { UUID = uuid, Tag = tag };
            return await PostAsync($"/tags/attachTagToObject", atr);
        }

        public async Task<string> Untag(Guid uuid, string tag)
        {
            AttachTagRequest atr = new AttachTagRequest() { UUID = uuid, Tag = tag };
            return await PostAsync($"/tags/removeTagFromObject", atr);
        }

        private async Task<string> ProposalAdd(MispEvent mispEvent, Attribute attribute)
        {
            return await ProposalAdd(mispEvent.Id.ToString(), attribute);
        }

        private async Task<string> ProposalAdd(string eid, Attribute attribute)
        {
            return await PostAsync($"/shadowAttributes/add/{eid}", attribute);
        }
        private async Task<string> ProposalAdd(MispEvent mispEvent, ShadowAttribute attribute)
        {
            return await ProposalAdd(mispEvent.Id.ToString(), attribute);
        }

        private async Task<string> ProposalAdd(string eid, ShadowAttribute attribute)
        {
            return await PostAsync($"/shadowAttributes/add/{eid}", attribute);
        }
    }
}
