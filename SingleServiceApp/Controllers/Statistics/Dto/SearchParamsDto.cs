namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public struct SearchParamsDto
    {
        public string TagName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid? TittleId { get; set; } = null;
    }
}
