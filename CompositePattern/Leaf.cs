using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public class Leaf : Component
    {
        public Leaf(string tag) : base(tag)
        {

        }

        public override void Operation(string suffix = "")
        {
            Console.WriteLine(suffix + Tag);
        }
    }
}
