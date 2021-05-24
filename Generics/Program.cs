using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        private static int int1, int2;
        private static float float1, float2;
        private static string string1, string2;

        private static DataSpecificSwapper dataSpecificSwapper = new DataSpecificSwapper();
        private static GenericSwapper genericSwapper = new GenericSwapper();

        static void Main(string[] args)
        {
            SetValues();

            Console.WriteLine("Data specific swap:");
            dataSpecificSwapper.Swap(ref int1, ref int2); // 1st method.
            dataSpecificSwapper.Swap(ref float1, ref float2); // 2nd method.
            dataSpecificSwapper.Swap(ref string1, ref string2); // 3rd method.

            PrintValues();

            SetValues();

            Console.WriteLine("Generic swap:");
            genericSwapper.Swap(ref int1, ref int2); // Only one method.
            genericSwapper.Swap(ref float1, ref float2); // Only one method.
            genericSwapper.Swap(ref string1, ref string2); // Only one method.

            PrintValues();

            Console.ReadKey(); // Wait for keydown.
        }

        /// <summary>
        /// Sets all variables to initial values.
        /// </summary>
        static void SetValues()
        {
            int1 = 1;
            int2 = 2;
            float1 = 1.1f;
            float2 = 2.2f;
            string1 = "first";
            string2 = "second";
        }

        /// <summary>
        /// Prints all variable values to the console.
        /// </summary>
        static void PrintValues()
        {
            Console.WriteLine(int1 + " , " + int2);
            Console.WriteLine(float1 + " , " + float2);
            Console.WriteLine(string1 + " , " + string2);
            Console.WriteLine("\n");
        }
    }
}
