using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCoverage
{
    class Program
    {
        private static TicketBooth ticketBooth = new TicketBooth();
        private static Calendar calendar = new Calendar();

        static void Main(string[] args)
        {
            int age = 15;
            int ticketPrice = ticketBooth.PriceByAge(age);
            Console.WriteLine($"Ticket price for a {age}-year-old is {ticketPrice}.");

            int monthNumber = 4;
            string month = calendar.MonthByNumber(monthNumber);
            Console.WriteLine($"\nMonth number {monthNumber} is " + month + ".");

            Console.ReadKey();
        }
    }
}
