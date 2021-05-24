using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public abstract class Unit
    {
        protected string type;
        protected int health;

        public Unit(string type, int health)
        {
            this.type = type;
            this.health = health;
        }

        public abstract void Report();
    }
}
