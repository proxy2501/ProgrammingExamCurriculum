using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class SpiderBuilder : IMonsterBuilder
    {
        private Monster monster = new Monster("eight-legged spider");
        public void BuildBody()
        {
            monster.AddBodyPart("1 spider body");

        }

        public void BuildHead()
        {
            monster.AddBodyPart("1 spider head");
        }

        public void BuildArms()
        {
            // Spiders don't have arms.
        }

        public void BuildLegs()
        {
            monster.AddBodyPart("8 spider legs");

        }

        public Monster GetResult()
        {
            Monster result = monster;
            monster = new Monster("eight-legged spider");
            return result;
        }
    }
}
