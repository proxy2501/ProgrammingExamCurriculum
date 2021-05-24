using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LazyLoading
{
    public class LazyLoadedClass
    {
        private string data;

        public string Data
        {
            get
            {
                if (String.IsNullOrEmpty(data))
                {
                    data = "This is the data contained within LazyLoadedClass.";
                    Thread.Sleep(100); // Simulate loading time.
                }

                return data;
            }
        }
    }
}
