using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Auth.Di;

using Statistic.Di;
using Statistic.Di.Tag;

namespace Statistic.Bll
{
    internal class Statistic : IStatistic
    {
        public IUserIdentity User => throw new NotImplementedException();

        public ITag Tag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { set => throw new NotImplementedException(); }

        public DateTime Date => throw new NotImplementedException();

        public double Value => throw new NotImplementedException();

        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string IStatisticEssentialsData.Title => throw new NotImplementedException();

        public bool Equals(IStatistic? other) => throw new NotImplementedException();
    }
}
