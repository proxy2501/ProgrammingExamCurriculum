using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public interface IMonsterBuilder
    {
        Monster GetResult();
        void BuildBody();
        void BuildHead();
        void BuildArms();
        void BuildLegs();
    }
}
