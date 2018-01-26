using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using OlmeLabs.LogAggregator.Configuration;
using OlmeLabs.LogAggregator.Models;
using OlmeLabs.LogAggregator.Repositories;

namespace OlmeLabs.LogAggregator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStorageFactory _storageFactory;
        private readonly IAppSettings _settings;

        public HomeController(IStorageFactory storageFactory, IAppSettings settings)
        {
            _storageFactory = storageFactory;
            _settings = settings;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Search Logs";

            var model = await DoSearch(SearchMode.RecentPage, new SearchOptionsModel());

            return View("Index", model);
        }

        public async Task<ActionResult> Search(SearchOptionsModel opt)
        {
            if (!ModelState.IsValid)
                return View("Index");

            var model = await DoSearch(SearchMode.Keywords, opt);

            return View("Index", model);
        }

        public async Task<ActionResult> Details(string id)
        {
            IStorage s = _storageFactory.ResolveStorage();

            var model = await s.GetById(id);

            return View("Details", model);
        }

        private async Task<SearchViewModel> DoSearch(SearchMode mode, SearchOptionsModel opt)
        {
            IStorage s = _storageFactory.ResolveStorage();

            var searchOptions = Mapper.Map<SearchOptions>(opt);
            searchOptions.PageSize = _settings.PageSize;
            searchOptions.Mode = mode;

            var model = new SearchViewModel
            {
                SearchOptions = searchOptions,
                SearchResults = await s.SearchAsync(searchOptions)
            };

            return model;
        }
    }
}
