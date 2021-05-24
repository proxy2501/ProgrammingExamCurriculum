using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public abstract class Component
    {
        public string Tag { get; private set; }

        public Component(string tag)
        {
            Tag = tag;
        }

        public abstract void Operation(string suffix);
    }
}
