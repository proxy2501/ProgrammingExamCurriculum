using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            MonsterDirector monsterDirector = new MonsterDirector();
            IMonsterBuilder ogreBuilder = new OgreBuilder();
            IMonsterBuilder ogreMagiBuilder = new OgreMagiBuilder();

            // Build 2 ogres.
            monsterDirector.Builder = ogreBuilder;

            monsterDirector.Construct();
            Monster ogre1 = ogreBuilder.GetResult();

            monsterDirector.Construct();
            Monster ogre2 = ogreBuilder.GetResult();

            // Build 1 ogre magi.
            monsterDirector.Builder = ogreMagiBuilder;

            monsterDirector.Construct();
            Monster ogreMagi = ogreMagiBuilder.GetResult();

            // Report results.
            ogre1.Report();
            ogre2.Report();
            ogreMagi.Report();

            Console.ReadKey();
        }
    }
}
