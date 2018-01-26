namespace OlmeLabs.LogAggregator.Models
{
    /// <summary>
    /// search options
    /// </summary>
    public class SearchOptions
    {
        /// <summary>
        /// ctor
        /// </summary>
        public SearchOptions()
        {
            CurrentPage = 1;
            PageSize = 10;
            Mode = SearchMode.Keywords;
        }

        /// <summary>
        /// page size
        /// </summary>
        public int PageSize { get; set; }
        
        /// <summary>
        /// current page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// search keywords
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Search mode. Search either by keywords or show recent list
        /// </summary>
        public SearchMode Mode { get; set; }
    }

    public enum SearchMode
    {
        Keywords,
        RecentPage,
    }
 }