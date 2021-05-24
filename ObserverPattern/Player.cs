using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Player : IListener
    {
        public void OnNotify(GameEvent gameEvent)
        {
            if (gameEvent.Title == "PlayerDeath")
            {
                if (Program.PlayerDeaths == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Achievement unlocked: First death!\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
