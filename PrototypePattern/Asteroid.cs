using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Asteroid: ICloneable<Asteroid>
    {
        public int Diameter { get; set; } = 0;
        public float Speed { get; set; } = 0f;
        public bool IsClone { get; set; } = false;

        /// <summary>
        /// Creates a shallow clone of this object.
        /// </summary>
        /// <returns>An Asteroid object that is a shallow clone of this object.</returns>
        public Asteroid Clone()
        {
            Asteroid clone = (Asteroid)this.MemberwiseClone();
            clone.IsClone = true;
            return clone;
        }

        /// <summary>
        /// Writes member values in the console.
        /// </summary>
        public void Report()
        {
            Console.WriteLine("Diameter: " + Diameter);
            Console.WriteLine("Speed: " + Speed);
            Console.WriteLine("Clone: " + IsClone);
            Console.WriteLine("\n");
        }
    }
}
