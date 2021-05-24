using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Program
    {
        static Random rnd = new Random();
        static Grid grid; // The grid of nodes on which to search.
        static Grid oldGrid; // A cached version of the grid used to detect changes in node states.
        static AStarPathfinder pathfinder; // A pathfinder that searches for paths on the grid.

        static int gridSizeX = Console.BufferWidth; // Number of nodes on the x-axis.
        static int gridSizeY = Console.WindowHeight - 1; // Number of nodes on the y-axis.

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (true)
            {
                grid = new Grid(gridSizeX, gridSizeY);
                oldGrid = new Grid(gridSizeX, gridSizeY);
                pathfinder = new AStarPathfinder(grid) { DiagonalMovementAllowed = true }; // <-- Change to investigate difference.

                // Block random nodes.
                for (int i = 0; i < gridSizeX * gridSizeY / 3; i++)
                {
                    Node randomNode = grid.Nodes[rnd.Next(0, gridSizeX), rnd.Next(0, gridSizeY)];
                    randomNode.Color = ConsoleColor.DarkGray;
                    randomNode.Walkable = false;
                }

                // Place a start node.
                Node start = grid.Nodes[rnd.Next(0, gridSizeX), rnd.Next(0, gridSizeY)];
                start.Color = ConsoleColor.Green;
                start.Walkable = true;

                // Place an end node.
                Node end = grid.Nodes[rnd.Next(0, gridSizeX), rnd.Next(0, gridSizeY)];
                end.Color = ConsoleColor.Red;
                end.Walkable = true;

                DrawUI();

                Console.ReadKey();

                pathfinder.FindPath(start, end);

                Console.ReadKey();
            }
        }

        /// <summary>
        /// Detects and draws any changes to the grid.
        /// </summary>
        public static void UpdateUI()
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (oldGrid.Nodes[x, y].Color != grid.Nodes[x, y].Color)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.BackgroundColor = grid.Nodes[x, y].Color;
                        Console.Write(' ');
                        oldGrid.Nodes[x, y].Color = grid.Nodes[x, y].Color;
                    }
                }
            }
        }

        /// <summary>
        /// Draws the entire grid.
        /// </summary>
        private static void DrawUI()
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.BackgroundColor = grid.Nodes[x, y].Color;
                    Console.Write(' ');
                }
            }
        }
    }
}
