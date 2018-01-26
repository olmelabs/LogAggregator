using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OlmeLabs.LogAggregator.Models;
using OlmeLabs.LogAggregator.Repositories;

namespace OlmeLabs.LogAggregator.Controllers
{
    /// <summary>
    /// search api
    /// </summary>
    public class SearchController : ApiController
    {
        private readonly IStorageFactory _storageFactory;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="storageFactory"></param>
        public SearchController(IStorageFactory storageFactory)
        {
            _storageFactory = storageFactory;
        }

        /// <summary>
        /// Search storage.
        /// </summary>
        /// <param name="searchOptions"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<LogEntry>))]
        public async Task<IHttpActionResult> Search([FromUri] SearchOptions searchOptions)
        {
            if (searchOptions == null)
            {
                return BadRequest("Invalid search options");
            }

            IStorage s = _storageFactory.ResolveStorage();
            var searchResult = await s.SearchAsync(searchOptions);

            return Ok(searchResult);
        }
    }
}