using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        private static GameEvent playerDeath = new GameEvent("PlayerDeath");
        
        public static int PlayerDeaths { get; private set; } = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Player player = new Player();
                Enemy enemy1 = new Enemy() { Tag = "Enemy1" };
                Enemy enemy2 = new Enemy() { Tag = "Enemy2" };

                playerDeath.Attach(player);
                playerDeath.Attach(enemy1);
                playerDeath.Attach(enemy2);

                Console.WriteLine("Press any button to kill player...\n");
                Console.ReadKey();
                Console.Clear();
                KillPlayer();

                Console.ReadKey();

                Console.Clear();
                playerDeath.Detach(player);
                playerDeath.Detach(enemy1);
                playerDeath.Detach(enemy2);
            }
        }

        private static void KillPlayer()
        {
            Console.WriteLine("Player died of a heart attack.\n");
            playerDeath.Notify();
            PlayerDeaths++;
        }
    }
}
