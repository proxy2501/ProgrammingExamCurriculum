using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class EatState : IState<Cat>
    {
        Cat cat;

        public void Enter(Cat entity)
        {
            cat = entity;
            Program.WriteLogLine($"{cat.Name} started eating...");
        }

        public void Execute()
        {
            if (cat.Fatigue >= cat.MaxFatigue)
            {
                Exit();
                return;
            }

            if (cat.Hunger >= cat.Boredom - 2 && cat.Hunger > 0)
            {
                Program.WriteLogLine("Nom nom");
                cat.Hunger--;
                if (cat.Boredom < cat.MaxBoredom)
                    cat.Boredom++;
                if (cat.Fatigue < cat.MaxFatigue)
                    cat.Fatigue++;
            }
            else
            {
                Exit();
            }
        }

        public void Exit()
        {
            Program.WriteLogLine($"{cat.Name} stopped eating.");

            if (cat.Fatigue >= cat.MaxFatigue)
            {
                cat.ChangeState(new SleepState());
            }
            else
            {
                cat.ChangeState(new StareIntoSpaceState());
            }
        }
    }
}
