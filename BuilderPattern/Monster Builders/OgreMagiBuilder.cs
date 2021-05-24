using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class OgreMagiBuilder : IMonsterBuilder
    {
        private Monster monster = new Monster("ogre magi");

        public void BuildBody()
        {
            monster.AddBodyPart("1 ogre body");

        }

        public void BuildHead()
        {
            monster.AddBodyPart("1 clever ogre head");
            monster.AddBodyPart("1 stupid ogre head");
        }

        public void BuildArms()
        {
            monster.AddBodyPart("1 magic ogre arm");
            monster.AddBodyPart("1 strong ogre arm");
        }

        public void BuildLegs()
        {
            monster.AddBodyPart("2 ogre legs");

        }

        public Monster GetResult()
        {
            Monster result = monster;
            monster = new Monster("ogre magi");
            return result;
        }
    }
}
