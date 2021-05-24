using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class Worker : Unit
    {
        private string tool;

        public Worker(string type, int health, string tool) : base(type, health)
        {
            this.tool = tool;
        }

        public override void Report()
        {
            Console.WriteLine("Worker type: " + type);
            Console.WriteLine("Health: " + health + ", Tool: " + tool);
            Console.WriteLine("\n");
        }
    }
}
