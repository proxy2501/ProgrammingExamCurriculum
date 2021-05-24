using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public interface ISortingStrategy
    {
        void Sort<T>(IList<T> collection) where T : IComparable<T>;
    }
}
