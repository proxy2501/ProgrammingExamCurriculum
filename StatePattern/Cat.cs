using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Cat
    {
        private IState<Cat> currentState;

        public string Name { get; private set; } = "Cat";
        public int MaxHunger { get; private set; } = 5;
        public int MaxFatigue { get; private set; } = 5;
        public int MaxBoredom { get; private set; } = 5;
        public int Hunger { get; set; } = 2;
        public int Fatigue { get; set; } = 5;
        public int Boredom { get; set; } = 4;

        /// <summary>
        /// Creates a cat in the sleeping state.
        /// </summary>
        public Cat()
        {
            currentState = new SleepState();
            currentState.Enter(this);
        }

        /// <summary>
        /// Updates the cat according to its state.
        /// </summary>
        public void Update()
        {
            currentState.Execute();
        }

        /// <summary>
        /// Changes cat's current state to the state provided as parameter.
        /// </summary>
        /// <param name="newState">The new state.</param>
        public void ChangeState(IState<Cat> newState)
        {
            currentState = newState;
            newState.Enter(this);
        }
    }
}
