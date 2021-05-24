using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericSwapper
    {
        /// <summary>
        /// Swaps values of two variables using the generic datatype.
        /// </summary>
        /// <typeparam name="T">The datatype of variables to be swapped.</typeparam>
        /// <param name="param1">The first variable (ref).</param>
        /// <param name="param2">The second variable (ref)</param>
        public void Swap<T>(ref T param1, ref T param2)
        {
            T temp = param1;
            param1 = param2;
            param2 = temp;
        }
    }
}
