using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCoverage
{
    public class Calendar
    {
        /// <summary>
        /// Returns the name of a month based on an integer.
        /// </summary>
        /// <param name="monthNumber">The number of the month.</param>
        /// <returns>The name of the corresponding month.</returns>
        public string MonthByNumber(int monthNumber)
        {
            if (monthNumber == 1) return "January";
            else if (monthNumber == 2) return "February";
            else if (monthNumber == 3) return "March";
            else if (monthNumber == 4) return "April";
            else if (monthNumber == 5) return "May";
            else if (monthNumber == 6) return "June";
            else if (monthNumber == 7) return "July";
            else if (monthNumber == 8) return "August";
            else if (monthNumber == 9) return "September";
            else if (monthNumber == 10) return "October";
            else if (monthNumber == 11) return "November";
            else if (monthNumber == 12) return "December";
            else throw new ArgumentException("Number must be between 1 and 12");
        }
    }
}
