namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class TagDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double? MaxValue { get; set; }
    }
}
