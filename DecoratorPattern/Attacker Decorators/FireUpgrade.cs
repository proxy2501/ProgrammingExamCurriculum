using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class FireUpgrade : AttackerDecorator
    {
        public FireUpgrade(IAttacker attacker) : base(attacker)
        {
        }

        public override void Attack()
        {
            attacker.Attack();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Target was set on fire!");
            Console.ResetColor();
        }
    }
}
