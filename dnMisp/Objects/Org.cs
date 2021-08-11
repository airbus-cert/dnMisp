﻿using dnMisp.Misc;
using Newtonsoft.Json;
using System;

namespace dnMisp.Objects
{
    /// <summary>
    /// https://www.misp-project.org/documentation/openapi.html#tag/Organisations
    /// </summary>
    public class Org 
        : JsonMispObject
    {
        /// <summary>
        /// The id is a human-readable identifier generated by the instance and used as reference in the event.
        /// </summary>
        [JsonProperty("id"), JsonRequired]
        public string Id { get; set; }

        /// <summary>
        /// The name is a readable description of the organization
        /// </summary>
        [JsonProperty("name"), JsonRequired]
        public string Name { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("sector")]
        public string Sector { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty("contacts")]
        public string Contacts { get; set; }
        [JsonProperty("local")]
        public bool Local { get; set; }

        [JsonProperty("restricted_to_domain")]
        public string[] RestrictedToDomains { get; set; }

        [JsonProperty("landingpage")]
        public string LandingPage { get; set; }

        [JsonProperty("user_count")]
        public string UserCount { get; set; }

        [JsonProperty("created_by_email")]
        public string CreatedByEmail { get; set; }

        /// <summary>
        /// The uuid represents the Universally Unique IDentifier (UUID) [@!RFC4122] of the organization. The organization UUID is globally assigned to an organization and SHALL be kept overtime.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }
    }
}