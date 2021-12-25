using Statistic.Di.Tag;
using Statistic.Di.Tittle;

using System.ComponentModel.DataAnnotations;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class StatisticCreationDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic tag is required")]
        public Guid TagId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic tag is required")]
        public Guid UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic date is required")]
        public DateTime Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic title is required")]
        public Guid TitleId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic value is required")]
        public double Value { get; set; }
    }
}
