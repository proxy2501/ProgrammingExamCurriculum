using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // A player composite.
            Composite player = new Composite("Player");
            player.Add(new Leaf("SprinteRenderer"));
            player.Add(new Leaf("Collider"));
            player.Add(new Leaf("InputHandler"));

            // A button composite.
            Composite button = new Composite("Button");
            button.Add(new Leaf("SpriteRenderer"));
            button.Add(new Leaf("TextRenderer"));

            // A menu composite, containing button composite.
            Composite menu = new Composite("Menu");
            menu.Add(new Leaf("SprinteRenderer"));
            menu.Add(new Leaf("TextRenderer"));
            menu.Add(button);

            player.Operation();

            Console.WriteLine();

            menu.Operation();

            Console.ReadKey();
        }
    }
}
