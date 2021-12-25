﻿using System.Text.Json;

namespace WelcomeDev.Utils.Json.Microsoft
{
    public class PascalCaseNamingPolicy : JsonNamingPolicy
    {
        public static JsonNamingPolicy Policy { get; } = new PascalCaseNamingPolicy();

        private PascalCaseNamingPolicy()
        {
        }

        public override string ConvertName(string name)
        {
            if (char.IsLower(name[0]))
                return char.ToLower(name[0]) + name.Substring(1);

            return name;
        }
    }
}
