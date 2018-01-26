using System.Threading.Tasks;
using OlmeLabs.LogAggregator.Models;

namespace OlmeLabs.LogAggregator.Repositories
{
    /// <summary>
    /// IStorage interface
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Store data
        /// </summary>
        /// <param name="entry"></param>
        /// <returns>empty task</returns>
        Task StoreAsync(LogEntry entry);

        /// <summary>
        /// Search storage
        /// </summary>
        /// <param name="searchOptions"></param>
        /// <returns></returns>
        Task<SearchResults> SearchAsync(SearchOptions searchOptions);

        /// <summary>
        /// Get object by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LogEntry> GetById(string id);
    }
}