using System.Threading.Tasks;
using OlmeLabs.LogAggregator.Models;

namespace OlmeLabs.LogAggregator.Repositories
{
    /// <summary>
    /// Empty storage
    /// </summary>
    public class NoStorage : IStorage
    {
        public async Task StoreAsync(LogEntry entry)
        {
            await Task.FromResult(0);
        }

        public async Task<SearchResults> SearchAsync(SearchOptions searchOptions)
        {
            return await Task.FromResult(new SearchResults());
        }

        public async Task<LogEntry> GetById(string id)
        {
            return await Task.FromResult((LogEntry)null);
        }
    }
}