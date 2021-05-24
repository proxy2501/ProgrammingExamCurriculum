using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class SleepState : IState<Cat>
    {
        Cat cat;

        public void Enter(Cat entity)
        {
            cat = entity;
            Program.WriteLogLine($"{cat.Name} went to sleep...");
        }

        public void Execute()
        {
            if (cat.Fatigue > 0)
            {
                Program.WriteLogLine("zZz...");
                cat.Fatigue--;
            }
            else
            {
                Exit();
            }
        }

        public void Exit()
        {
            Program.WriteLogLine($"{cat.Name} woke up!");

            if (cat.Hunger > cat.Boredom)
            {
                cat.ChangeState(new EatState());
            }
            else
            {
                cat.ChangeState(new StareIntoSpaceState());

            }
        }
    }
}
