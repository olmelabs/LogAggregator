using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using OlmeLabs.LogAggregator.Models;
using OlmeLabs.LogAggregator.Repositories;

namespace OlmeLabs.LogAggregator.Controllers
{
    /// <summary>
    /// Log Api
    /// </summary>
    public class LogController : ApiController
    {
        private readonly IStorageFactory _storageFactory;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="storageFactory"></param>
        public LogController(IStorageFactory storageFactory)
        {
            _storageFactory = storageFactory;
        }


        /// <summary>
        /// Store Log Entry from External system.
        /// </summary>
        /// <param name="entry">New log entry</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Post(NewLogEntry entry)
        {
            IStorage s = _storageFactory.ResolveStorage();
            await s.StoreAsync(Mapper.Map<LogEntry>(entry));
            return Ok();
        }
    }
}
