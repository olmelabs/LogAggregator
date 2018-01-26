using System.Collections.Generic;

namespace OlmeLabs.LogAggregator.Models
{
    /// <summary>
    /// Serach Resuls
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// ctor
        /// </summary>
        public SearchResults()
        {
            Result = new List<LogEntry>();
        }

        /// <summary>
        /// result count
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// result list
        /// </summary>
        public List<LogEntry> Result { get; set; }
    }
}