using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class SoldierFactory : UnitFactory
    {
        public override Unit Create(string type)
        {
            switch (type)
            {
                case "Trooper":
                    return new Soldier(type, 100, "Machine Gun");

                case "Sniper":
                    return new Soldier(type, 60, "Sniper Rifle");

                case "Rambo":
                    return new Soldier(type, 150, "Manliness");
                
                default:
                    throw new ArgumentException("Invalid type.");
            }
        }
    }
}
