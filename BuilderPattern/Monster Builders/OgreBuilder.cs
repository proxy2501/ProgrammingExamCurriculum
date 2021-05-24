using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class OgreBuilder : IMonsterBuilder
    {
        private Monster monster = new Monster("two-headed ogre");

        public void BuildBody()
        {
            monster.AddBodyPart("1 ogre body");

        }

        public void BuildHead()
        {
            monster.AddBodyPart("2 stupid ogre heads");
        }


        public void BuildArms()
        {
            monster.AddBodyPart("2 strong ogre arms");

        }

        public void BuildLegs()
        {
            monster.AddBodyPart("2 ogre legs");

        }

        public Monster GetResult()
        {
            Monster result = monster;
            monster = new Monster("two-headed ogre");
            return result;
        }
    }
}
