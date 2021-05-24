using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCoverage
{
    public class TicketBooth
    {
        /// <summary>
        /// Gets the price of a train ticket based on rider age.
        /// </summary>
        /// <param name="age">The age of the rider.</param>
        /// <returns>The price of the ticket.</returns>
        public int PriceByAge(int age)
        {
            if (age >= 0 && age <= 1) return 0;
            else if (age >= 2 && age <= 14) return 10;
            else if (age >= 15 && age <= 64) return 20;
            else if (age >= 65) return 5;
            else throw new ArgumentException("Age must be higher than 0");
        }
    }
}
