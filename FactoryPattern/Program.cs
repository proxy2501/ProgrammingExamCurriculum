using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        private static UnitFactory solderFactory = new SoldierFactory();
        private static UnitFactory workerFactory = new WorkerFactory();

        static void Main(string[] args)
        {
            // Create units.
            Unit unit2 = workerFactory.Create("Builder");
            Unit unit1 = workerFactory.Create("Forester");
            Unit unit3 = workerFactory.Create("Farmer");
            Unit unit4 = solderFactory.Create("Trooper");
            Unit unit5 = solderFactory.Create("Sniper");
            Unit unit6 = solderFactory.Create("Rambo");

            // Report unit stats.
            unit1.Report();
            unit2.Report();
            unit3.Report();
            unit4.Report();
            unit5.Report();
            unit6.Report();

            // Wait.
            Console.ReadKey();
        }
    }
}
