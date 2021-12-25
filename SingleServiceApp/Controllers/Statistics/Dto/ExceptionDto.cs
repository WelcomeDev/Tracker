namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class ExceptionDto
    {
        public int Status { get; }
        public string Message { get; }

        public ExceptionDto(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
