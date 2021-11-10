using System.Text;
using System.Text.Json;

namespace WelcomeDev.Utils
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        private const char Separator = '_';

        public static JsonNamingPolicy Policy { get; } = new SnakeCaseNamingPolicy();

        private SnakeCaseNamingPolicy()
        { }

        public override string ConvertName(string name)
        {
            StringBuilder result = new StringBuilder(2 * name.Length);
            foreach (var ch in name)
            {
                if (char.IsLower(ch))
                {
                    result.Append(Separator);
                    result.Append(char.ToLowerInvariant(ch));
                }
                else
                    result.Append(ch);
            }

            return result.ToString();
        }
    }
}
