using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public class Composite : Component
    {
        private List<Component> subComponents = new List<Component>();

        public Composite(string tag) : base(tag)
        {

        }

        public void Add(Component component)
        {
            subComponents.Add(component);
        }
        public void Remove(Component component)
        {
            subComponents.Remove(component);
        }

        public override void Operation(string suffix = "")
        {
            Console.WriteLine(suffix + Tag);

            foreach (Component component in subComponents)
            {
                component.Operation(suffix + "-");
            }
        }
    }
}
