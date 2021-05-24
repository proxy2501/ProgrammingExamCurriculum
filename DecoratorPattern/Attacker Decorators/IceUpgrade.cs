using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class IceUpgrade : AttackerDecorator
    {
        public IceUpgrade(IAttacker attacker) : base(attacker)
        {
        }

        public override void Attack()
        {
            attacker.Attack();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Target was frozen!");
            Console.ResetColor();
        }
    }
}
