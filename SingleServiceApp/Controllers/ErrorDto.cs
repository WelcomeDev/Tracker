namespace SingleServiceApp.Controllers
{
    public class ErrorDto
    {
        public int Status { get; }
        public string Message { get; }

        public ErrorDto(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
