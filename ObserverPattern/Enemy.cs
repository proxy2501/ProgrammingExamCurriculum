using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Enemy : IListener
    {
        public string Tag { get; set; }

        public void OnNotify(GameEvent gameEvent)
        {
            if (gameEvent.Title == "PlayerDeath")
            {
                Console.WriteLine($"{Tag}: gg!");
            }
        }
    }
}
