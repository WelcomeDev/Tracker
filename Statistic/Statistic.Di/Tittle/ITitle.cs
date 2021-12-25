using Statistic.Di.Tag;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Di.Tittle
{
    public interface ITitle
    {
        Guid Id { get; }

        public string Name { get; set; }

        public ITag Tag { get; }

        public Color ColorSql { get; }

    }
}
