using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Monster
    {
        private string type;
        private List<string> bodyParts = new List<string>();

        public Monster(string type)
        {
            this.type = type;
        }

        public void AddBodyPart(string bodyPart)
        {
            bodyParts.Add(bodyPart);
        }

        public void Report()
        {
            Console.WriteLine("\n" + type);
            foreach (string bodyPart in bodyParts)
            {
                Console.WriteLine(bodyPart);
            }
        }
    }
}
