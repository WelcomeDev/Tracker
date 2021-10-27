using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll.Provider
{
    internal static class DbValidationConfig
    {
        public const int StatValueMin = 0;
        public const int StatValueMax = 1000;

        public const int TitleMinLength = 2;
        public const int TitleMaxLength = 100;
    }
}
