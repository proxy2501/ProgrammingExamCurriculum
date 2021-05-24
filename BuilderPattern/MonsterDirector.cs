using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class MonsterDirector
    {
        public IMonsterBuilder Builder { private get; set; }

        public void Construct()
        {
            Builder.BuildBody();
            Builder.BuildHead();
            Builder.BuildArms();
            Builder.BuildLegs();
        }
    }
}
