using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class SortingMachine
    {
        public ISortingStrategy Strategy { get; set; }

        public SortingMachine(ISortingStrategy strategy)
        {
            Strategy = strategy;
        }

        public void Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            Strategy.Sort(collection);
        }
    }
}
