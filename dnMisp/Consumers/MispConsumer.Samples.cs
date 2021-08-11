using dnMisp.Enums;
using dnMisp.Misc;
using dnMisp.Objects;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace dnMisp
{
    public partial class MispConsumer
    {
        private const string MISP_URI_UPLOAD_SAMPLE = "/events/upload_sample";
        private const string MISP_URI_ADD_TAG = "events/addTag";

        #region Upload Sample
        public async Task<string> UploadSample(string eid, SampleUpload sampleUpload)
        {
            string url;
            if (string.IsNullOrWhiteSpace(eid))
                url = MISP_URI_UPLOAD_SAMPLE;
            else
                url = $"{MISP_URI_UPLOAD_SAMPLE }/{eid}";

            return await PostAsync(url, sampleUpload);
        }

        public async Task<string> UploadSample(
            string eid,
            string filename,
            Stream file,
            string category = "Payload delivery",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            ThreatLevel threatLevel = ThreatLevel.Undefined,
            bool advancedExtraction = false)
        {
            SampleUpload su = new SampleUpload()
            {
                SampleUploadRequest = new SampleUploadRequest()
                {
                    Category = category,
                    Comment = comment,
                    ToIDS = toIds,
                    Files = new List<SampleFile>(),
                    Distribution = distribution,
                    ThreatLevelId = threatLevel,
                    Advanced = advancedExtraction
                }
            };

            file.Seek(0, SeekOrigin.Begin);
            var b64Stream = Helper.ConvertToBase64(file);
            StreamReader reader = new StreamReader(b64Stream);
            var sampleFile = new SampleFile();
            sampleFile.Filename = filename;
            sampleFile.Data = reader.ReadToEnd();
            su.SampleUploadRequest.Files.Add(sampleFile);

            return await UploadSample(eid, su);
        }


        public async Task<string> AddTag(string eid, string tag, bool attribute = false)
        {
            JsonMispObject req;
            if (attribute)
            {
                req = new JsonMispRequest<AddAttributeTagRequest>()
                {
                    RequestObject = new AddAttributeTagRequest()
                    {
                        Attribute = new AddTagRequest()
                        {
                            EventId = eid,
                            Tag = tag
                        }

                    }
                };
            }
            else
            {
                req = new JsonMispRequest<AddEventTagRequest>()
                {
                    RequestObject = new AddEventTagRequest()
                    {
                        Event = new AddTagRequest()
                        {
                            EventId = eid,
                            Tag = tag
                        }

                    }
                };
            }

            return await PostAsync(MISP_URI_ADD_TAG, req);
        }
        #endregion
    }
}
