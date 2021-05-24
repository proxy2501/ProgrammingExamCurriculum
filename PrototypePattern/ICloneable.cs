using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public interface ICloneable<T> where T: class
    {
        T Clone();
    }
}
