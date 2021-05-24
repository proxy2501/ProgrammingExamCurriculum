using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class StareIntoSpaceState : IState<Cat>
    {
        Cat cat;

        public void Enter(Cat entity)
        {
            cat = entity;
            Program.WriteLogLine($"{cat.Name} started staring into space...");
        }

        public void Execute()
        {
            if (cat.Fatigue >= cat.MaxFatigue)
            {
                Exit();
                return;
            }

            if (cat.Boredom >= cat.Hunger - 2 && cat.Boredom > 0)
            {
                Program.WriteLogLine("(stare)");
                cat.Boredom--;
                if (cat.Fatigue < cat.MaxFatigue)
                    cat.Fatigue++;
                if (cat.Hunger < cat.MaxHunger)
                    cat.Hunger++;
            }
            else
            {
                Exit();
            }
        }

        public void Exit()
        {
            Program.WriteLogLine($"{cat.Name} stopped staring into space.");

            if (cat.Fatigue >= cat.MaxFatigue)
            {
                cat.ChangeState(new SleepState());
            }
            else
            {
                cat.ChangeState(new EatState());
            }
        }
    }
}
