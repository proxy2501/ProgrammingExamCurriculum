using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class DataSpecificSwapper
    {
        /// <summary>
        /// Swaps values of two integer variables.
        /// </summary>
        /// <param name="int1">An integer (ref).</param>
        /// <param name="int2">An integer (ref).</param>
        public void Swap(ref int int1, ref int int2)
        {
            int temp = int1;
            int1 = int2;
            int2 = temp;
        }

        /// <summary>
        /// Swaps values of two float variables.
        /// </summary>
        /// <param name="float1">A float (ref).</param>
        /// <param name="float2">A float (ref).</param>
        public void Swap(ref float float1, ref float float2)
        {
            float temp = float1;
            float1 = float2;
            float2 = temp;
        }

        /// <summary>
        /// Swaps values of two string variables.
        /// </summary>
        /// <param name="string1">A string (ref).</param>
        /// <param name="string2">A string (ref).</param>
        public void Swap(ref string string1, ref string string2)
        {
            string temp = string1;
            string1 = string2;
            string2 = temp;
        }
    }
}
