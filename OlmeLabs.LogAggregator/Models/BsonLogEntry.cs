using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OlmeLabs.LogAggregator.Models
{
    /// <summary>
    /// Bson Log Entry. 
    /// </summary>
    public class BsonLogEntry
    {
        /// <summary>
        /// Bson Id from Mongo
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }
        /// <summary>
        /// Log Sys 
        /// </summary>
        public string Sys { get; set; }
        /// <summary>
        /// Log Env
        /// </summary>
        public string Env { get; set; }
        /// <summary>
        /// Log Severity
        /// </summary>
        public string Severity { get; set; }
        /// <summary>
        /// Log entry date 
        /// </summary>
        public DateTime StoreDate { get; set; }
        /// <summary>
        /// log Content
        /// </summary>
        public string Content { get; set; }
    }
}