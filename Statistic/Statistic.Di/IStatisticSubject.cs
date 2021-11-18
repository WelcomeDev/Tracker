using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Di
{
    public interface IStatisticSubject
    {
        string Title { get; set; } 
        
        Color Color { get; set; }
    }
}
