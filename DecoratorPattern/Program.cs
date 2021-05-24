using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IAttacker player1 = new Player();
                IAttacker player2 = new Player();

                Console.WriteLine("Player 1 attacks.");
                player1.Attack();
                Console.ReadLine();

                Console.WriteLine("Player 1 got a fire upgrade!");
                player1 = new FireUpgrade(player1);
                Console.ReadLine();

                Console.WriteLine("Player 1 attacks.");
                player1.Attack();
                Console.ReadLine();

                Console.WriteLine("Player 2 got an ice upgrade!");
                player2 = new IceUpgrade(player2);
                Console.ReadLine();

                Console.WriteLine("Player 2 attacks.");
                player2.Attack();
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
