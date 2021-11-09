using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Bll.Provider.MySql.Entity
{
    [ComplexType]
    internal class Duration
    {
        [Range(0,8)]
        public int Hours { get; set; }
        [Range(0,60)]
        public int Minutes { get; set; }
    }
}
