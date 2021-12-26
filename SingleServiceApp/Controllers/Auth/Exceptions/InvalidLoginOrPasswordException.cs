namespace SingleServiceApp.Controllers.Auth.Exceptions
{
    public class InvalidLoginOrPasswordException : Exception
    {
        private const string ErrorMessage = "Invalid username or password";
        public InvalidLoginOrPasswordException() : base(ErrorMessage)
        {        }
    }
}
