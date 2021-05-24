using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class AsteroidFactory
    {
        private Asteroid prototype = new Asteroid();

        public Asteroid Create(string type)
        {
            Asteroid product = prototype.Clone();

            type = type.ToLower();

            switch (type)
            {
                case "small":
                    product.Diameter = 25;
                    product.Speed = 120;
                    break;
                case "medium":
                    product.Diameter = 50;
                    product.Speed = 75;
                    break;
                case "large":
                    product.Diameter = 100;
                    product.Speed = 30;
                    break;
                default:
                    throw new ArgumentException("Not a valid type.");
            }

            return product;
        }
    }
}
