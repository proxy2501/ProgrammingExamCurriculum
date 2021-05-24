using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace LazyLoading
{
    public class EagerLoadedClass
    {
        public string Data { get; private set; }

        public EagerLoadedClass()
        {
            Data = "This is the data contained within EagerLoadedClass.";
            Thread.Sleep(100); // Simulate loading time.
        }
    }
}
