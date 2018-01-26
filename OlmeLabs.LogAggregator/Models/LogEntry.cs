using System;

namespace OlmeLabs.LogAggregator.Models
{
    /// <summary>
    /// Existing Log Entry
    /// </summary>
    public class LogEntry : NewLogEntry
    {
        /// <summary>
        /// Internal Log Id. Empty for new entries
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Log Date. Auto Generated
        /// </summary>
        public DateTime StoreDate { get; set; }
    }
}