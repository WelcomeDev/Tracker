namespace SingleServiceApp.Controllers.Auth.Dto
{
    public class Token
    {
        public string AccessToken { get; }

        public Token(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
