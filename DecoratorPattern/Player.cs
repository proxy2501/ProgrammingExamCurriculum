using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Player : IAttacker
    {
        private int baseDamage = 5;

        public void Attack()
        {
            Console.WriteLine($"{baseDamage} damage!");
        }
    }
}
