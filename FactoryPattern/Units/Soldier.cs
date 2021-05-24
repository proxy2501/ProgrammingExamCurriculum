using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class Soldier : Unit
    {
        private string weapon;

        public Soldier(string type, int health, string weapon) : base(type, health)
        {
            this.weapon = weapon;
        }

        public override void Report()
        {
            Console.WriteLine("Soldier type: " + type);
            Console.WriteLine("Health: " + health + ", Weapon: " + weapon);
            Console.WriteLine("\n");
        }
    }
}
