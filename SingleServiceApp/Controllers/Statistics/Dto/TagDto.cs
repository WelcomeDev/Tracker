using Auth.Di;

using Statistic.Di.Tag;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class TagDto : ITag
    {
        public IUserIdentity User { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }
        public double? MaxValue { get; set; }
    }
}
