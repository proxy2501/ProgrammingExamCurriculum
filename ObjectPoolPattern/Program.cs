using System;
using System.Collections.Generic;
using System.Threading;

namespace ObjectPoolPattern
{
    class Program
    {
        private static Random rnd = new Random();
        private static List<Block> blocks = new List<Block>();

        public static List<Block> DestroyedBlocks { get; private set; } = new List<Block>();
        public static int PlayFieldWidth { get; private set; } = Console.BufferWidth - 25;
        public static int PlayFieldHeight { get; private set; } = Console.WindowHeight - 1;
        public static BlockPool Pool { get; private set; } = new BlockPool(15); // <- Change pool size to evaluate difference.

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DrawStaticUIElements();

            while (true)
            {
                UpdateGame();
                UpdateCounters();
                Thread.Sleep(80);
            }
        }

        private static void DrawStaticUIElements()
        {
            for (int i = 0; i < PlayFieldHeight; i++)
            {
                Console.SetCursorPosition(PlayFieldWidth, i);
                Console.Write("|\n");
            }

            Console.SetCursorPosition(PlayFieldWidth + 1, 7);
            Console.Write($"Pool capacity: {Pool.Size}" + " ");
        }

        private static void UpdateGame()
        {
            if (rnd.Next(100) <= 25) // 25% chance of spawning a block.
            {
                blocks.Add(Pool.Get());
            }

            foreach (Block block in blocks)
            {
                block.MoveDownScreen();
            }

            foreach (Block destroyedBlock in DestroyedBlocks)
            {
                blocks.Remove(destroyedBlock);
            }

            DestroyedBlocks.Clear();
        }

        private static void UpdateCounters()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(PlayFieldWidth + 1, 1);
            Console.Write($"In game: {blocks.Count}" + " ");
            Console.SetCursorPosition(PlayFieldWidth + 1, 2);
            Console.Write($"In pool: {Pool.InactiveCount()}" + " ");
            Console.SetCursorPosition(PlayFieldWidth + 1, 3);
            Console.Write($"Total: {Pool.InactiveCount() + blocks.Count }" + " ");
            Console.SetCursorPosition(PlayFieldWidth + 1, 5);
            Console.Write($"Constructor called: {Block.TimesConstructorCalled}" + " ");
        }
    }
}
