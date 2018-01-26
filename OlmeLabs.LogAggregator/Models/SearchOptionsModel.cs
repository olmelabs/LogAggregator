using System.ComponentModel.DataAnnotations;

namespace OlmeLabs.LogAggregator.Models
{
    public class SearchOptionsModel
    {
        public SearchOptionsModel()
        {
            CurrentPage = 1;
        }

        public int CurrentPage { get; set; }

        [Required]
        public string Keywords { get; set; }
    }
}