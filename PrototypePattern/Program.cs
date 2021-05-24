using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        private static AsteroidFactory factory = new AsteroidFactory();

        static void Main(string[] args)
        {
            // Create clones using factory with a prototype.
            Asteroid clone1 = factory.Create("small");
            Asteroid clone2 = factory.Create("medium");
            Asteroid clone3 = factory.Create("large");

            // Report all asteroids' stats.
            clone1.Report();
            clone2.Report();
            clone3.Report();

            Console.ReadKey();
        }
    }
}
