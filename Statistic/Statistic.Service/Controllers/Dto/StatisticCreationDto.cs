using Statistic.Di.Tag;
using Statistic.Di.Tittle;
using System.ComponentModel.DataAnnotations;

namespace Statistic.Service.Controllers.Dto
{
    public class StatisticCreationDto 
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic tag is required")]
        public ITag Tag { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic date is required")]
        public DateTime Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic title is required")]
        public ITitle Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Statiistic value is required")]
        public double Value { get; set; }
    }
}
