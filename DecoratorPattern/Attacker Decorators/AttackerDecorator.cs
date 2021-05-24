using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public abstract class AttackerDecorator : IAttacker
    {
        protected IAttacker attacker;

        public AttackerDecorator(IAttacker attacker)
        {
            this.attacker = attacker;
        }

        public abstract void Attack();
    }
}
