using Auth.Di;
using Statistic.Di.Tag;
using Statistic.Di.Tittle;
using System.Drawing;

namespace Statistic.Service.Controllers.Dto
{
    public class TitleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }
    }
}
 