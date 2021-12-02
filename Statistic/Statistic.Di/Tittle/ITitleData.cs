using Statistic.Di.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Di.Tittle
{
    public interface ITitleData
    {
        Guid Id { get; }

        public string Name { get; set; }

        public ITagData Tag { get; }

    }
}
