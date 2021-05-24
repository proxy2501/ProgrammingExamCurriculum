using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class WorkerFactory : UnitFactory
    {
        public override Unit Create(string type)
        {
            switch (type)
            {
                case "Builder":
                    return new Worker(type, 50, "Hammer");

                case "Forester":
                    return new Worker(type, 50, "Axe");

                case "Farmer":
                    return new Worker(type, 50, "Sickle");
                
                default:
                    throw new ArgumentException("Invalid type.");
            }
        }
    }
}
