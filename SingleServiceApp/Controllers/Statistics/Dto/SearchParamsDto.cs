using System.ComponentModel.DataAnnotations;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class SearchParamsDto
    {
        [Required(ErrorMessage = "TagName is required")]
        public string TagName { get; set; }

        [Required(ErrorMessage = "Date from is required")]
        public string From { get; set; }

        [Required(ErrorMessage = "Date to is required")]
        public string To { get; set; }
    }
}
