
namespace OlmeLabs.LogAggregator.Models
{
    /// <summary>
    /// Class for storing new log entry
    /// </summary>
    public class NewLogEntry
    {
        /// <summary>
        /// The key which uniquely identifies sender
        /// </summary>
        public string Sys { get; set; }

        /// <summary>
        /// Environment. For example Test, Staging, Prod
        /// </summary>
        public string Env { get; set; }

        /// <summary>
        /// Entry Severity
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Log Content
        /// </summary>
        public string Content { get; set; }
    }
}