using System.Text.Json;

namespace WelcomeDev.Utils
{
    public class PascalCaseNamingPilicy : JsonNamingPolicy
    {
        public static JsonNamingPolicy Policy { get; } = new PascalCaseNamingPilicy();

        private PascalCaseNamingPilicy()
        {
        }

        public override string ConvertName(string name)
        {
            if (char.IsLower(name[0]))
            {
                return char.ToLower(name[0]) + name.Substring(1);
            }

            return name;
        }
    }
}
