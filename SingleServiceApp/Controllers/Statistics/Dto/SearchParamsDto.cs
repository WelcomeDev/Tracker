using System.ComponentModel.DataAnnotations;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class SearchParamsDto
    {
        [Required(ErrorMessage ="TagName is required")]
        public string TagName { get; set; }

        [Required(ErrorMessage = "Date from is required")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "Date to is required")]
        public DateTime To { get; set; }
    }
}
