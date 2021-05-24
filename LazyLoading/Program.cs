using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading
{
    class Program
    {
        private static Stopwatch stopWatch = new Stopwatch();
        private static int listLength = 10;
        private static List<EagerLoadedClass> eagerLoadedClasses = new List<EagerLoadedClass>();
        private static List<LazyLoadedClass> lazyLoadedClasses = new List<LazyLoadedClass>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Creating eager loaded classes...");
                stopWatch.Restart();
                for (int i = 0; i < listLength; i++)
                {
                    eagerLoadedClasses.Add(new EagerLoadedClass());
                }
                stopWatch.Stop();
                Console.WriteLine($"Done! Operation took {stopWatch.ElapsedMilliseconds} milliseconds.");

                Console.ReadKey();

                Console.WriteLine("\nDisplaying eager loaded data:");
                for (int i = 0; i < eagerLoadedClasses.Count; i++)
                {
                    Console.WriteLine(eagerLoadedClasses[i].Data);
                }

                Console.ReadKey();

                Console.WriteLine("\nCreating lazy loaded classes...");
                stopWatch.Restart();
                for (int i = 0; i < listLength; i++)
                {
                    lazyLoadedClasses.Add(new LazyLoadedClass());
                }
                stopWatch.Stop();
                Console.WriteLine($"Done! Operation took {stopWatch.ElapsedMilliseconds} milliseconds.");

                Console.ReadKey();

                Console.WriteLine("\nDisplaying lazy loaded data:");

                for (int i = 0; i < lazyLoadedClasses.Count; i++)
                {
                    Console.WriteLine(lazyLoadedClasses[i].Data);
                }

                Console.ReadKey();
                eagerLoadedClasses.Clear();
                lazyLoadedClasses.Clear();
                Console.Clear();
            }
        }
    }
}
