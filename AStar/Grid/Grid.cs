using System;
using System.Collections.Generic;

namespace AStar
{
    public class Grid
    {
        /// <summary>
        /// The number of nodes horizontally in the grid.
        /// </summary>
        public int SizeX { get; private set; }

        /// <summary>
        /// The number of nodes vertically in the grid.
        /// </summary>
        public int SizeY { get; private set; }

        /// <summary>
        /// A two-dimentional array that holds all nodes in the grid.
        /// </summary>
        public Node[,] Nodes { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sizeX">An integer equal to the number of nodes horizontally in the grid.</param>
        /// <param name="sizeY">An integer equal to the number of nodes vertically in the grid.</param>
        public Grid(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;

            Nodes = new Node[sizeX, sizeY];

            for (int x = 0; x < sizeX; x++) // Populate grid.
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Nodes[x, y] = new Node(x, y) { Color = ConsoleColor.Black, Walkable = true };
                }
            }
        }

        /// <summary>
        /// Gets a list of nodes that are adjacent to the input node.
        /// </summary>
        /// <param name="node">A Node.</param>
        /// <param name="diagonalAllowed">A bool indicating whether diagonal movement is allowed.</param>
        /// <returns>A List of Nodes that are adjacent to input Node.</returns>
        public List<Node> GetAdjacentNodes(Node node, bool diagonalAllowed)
        {
            List<Node> adjacencies = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    // Skip the node on index [0,0], as it is the center node (hence not an adjacenct node).
                    if (x == 0 && y == 0) continue;

                    // Skip diagonals if not allowed.
                    if (!diagonalAllowed && x != 0 && y != 0) continue;

                    // Create values for the potential adjacent node.
                    int adjacentX = node.X + x;
                    int adjacentY = node.Y + y;

                    // Add adjacent node if it lies within the grid.
                    if (adjacentX >= 0 && adjacentX < SizeX && adjacentY >= 0 && adjacentY < SizeY)
                    {
                        adjacencies.Add(Nodes[adjacentX, adjacentY]);
                    }
                }
            }

            return adjacencies;
        }
    }
}
