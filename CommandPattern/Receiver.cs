using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Receiver
    {
        private string name;

        public bool IsMute { get; set; } = false;

        public Receiver(string name)
        {
            this.name = name;
        }

        public void Say(string line)
        {
            Console.WriteLine(name + ": \"" + line + "\"");
        }
    }
}
