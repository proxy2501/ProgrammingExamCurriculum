﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.DoSomething(); // Call Singleton through its instance.
            Singleton.Instance.DoSomething(); // Call Singleton through its instance.
            Singleton.Instance.DoSomething(); // Call Singleton through its instance.

            Console.ReadKey(); // Wait.
        }
    }
}
