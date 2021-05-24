using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolPattern
{
    public class Block
    {
        /// <summary>
        /// Tracks how many times Block has been instantiated.
        /// </summary>
        public static int TimesConstructorCalled { get; private set; } = 0;

        /// <summary>
        /// X position of the block.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y position of the block.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Creates a new Block with the specified x and y positions.
        /// </summary>
        /// <param name="x">The block's x position.</param>
        /// <param name="y">The block's y position.</param>
        public Block(int x, int y)
        {
            X = x;
            Y = y;

            TimesConstructorCalled++;
        }

        /// <summary>
        /// Moves the block downwards by one tile.
        /// </summary>
        public void MoveDownScreen()
        {
            // Leaving this tile - paint it black.
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");

            Y++;

            if (Y > Program.PlayFieldHeight - 1)
            {
                Program.Pool.Release(this); // Out of bounds, return to pool.
            }
            else
            {
                // Entering this tile - paint it white.
                Console.SetCursorPosition(X, Y);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
        }
    }
}
