using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SingleServiceApp.AppConfiguration
{
    public static class AuthOptions
    {
        public const string Issuer = "Tracker_AuthService"; // издатель токена
        public const string Audience = "Tracker_Client"; // потребитель токена
        public const int TokenHoursLifeTime = 24;
        private const string Key = "708bdf8d-8f1a-4829-854a-c64180c33fec";   // ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}
