namespace SingleServiceApp.Controllers.Authorization
{
    public class AuthorizationException : Exception
    {
        private const string ErrorMessage = "Unauthorized";
        public AuthorizationException() : base(ErrorMessage)
        {

        }
    }
}
