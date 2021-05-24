using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        private static Cat cat = new Cat();

        static void Main(string[] args)
        {
            while (true)
            {
                cat.Update();
                UpdateUI();
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Writes a message in the log.
        /// </summary>
        /// <param name="message">The message to write in to log.</param>
        public static void WriteLogLine(string message)
        {
            // If bottom of console reached, jump to top.
            if (Console.CursorTop >= Console.WindowHeight - 2)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }

            Console.WriteLine(message);
        }

        /// <summary>
        /// Updates the UI elements that track fatigue, hunger and boredom.
        /// </summary>
        private static void UpdateUI()
        {
            int cursorX = Console.CursorLeft;
            int cursorY = Console.CursorTop;

            Console.SetCursorPosition(Console.BufferWidth - 15, 1);
            Console.Write($"| Fatigue: {cat.Fatigue} ");
            Console.SetCursorPosition(Console.BufferWidth - 15, 0);
            Console.Write($"| Hunger: {cat.Hunger} ");
            Console.SetCursorPosition(Console.BufferWidth - 15, 2);
            Console.Write($"| Boredom: {cat.Boredom} ");

            Console.SetCursorPosition(cursorX, cursorY);
        }
    }
}
