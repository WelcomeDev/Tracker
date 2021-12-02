﻿using Statistic.Di.Tag;
using Statistic.Di.Tittle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll
{
    internal class Title : ITitle
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Tag.Tag Tag { get; set; }

        ITagData ITitleData.Tag => Tag;


        public bool Equals(ITitle? other)
        {
            if (other is null)
                return false;

            return Name.Equals(other.Name);
        }
    }
}
