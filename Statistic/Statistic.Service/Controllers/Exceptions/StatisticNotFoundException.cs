namespace Statistic.Service.Controllers.Exceptions
{
    public class StatisticNotFoundException : Exception
    {
        private const string ErrorMessage = "Required statistic not found";
        public StatisticNotFoundException() : base(ErrorMessage)
        { }
    }
}
