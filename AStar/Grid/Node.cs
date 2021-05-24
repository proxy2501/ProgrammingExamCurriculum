using System;

namespace AStar
{
    public class Node : IHeapItem<Node>
    {
        /// <summary>
        /// The node's horizontal index in a two-dimensional grid array.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// The node's vertical index in a two-dimensional grid array.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Implemented from the IHeapItem interface.
        /// </summary>
        public int HeapIndex { get; set; }

        /// <summary>
        /// Determines if the node is walkable, allowing pathing over it.
        /// </summary>
        public bool Walkable { get; set; }

        /// <summary>
        /// The GCost of the node, used in AStar pahfinding.
        /// </summary>
        public int GCost { get; set; }

        /// <summary>
        /// The HCost of the node, used in AStar pahfinding.
        /// </summary>
        public int HCost { get; set; }

        /// <summary>
        /// The FCost of the node, used in AStar pahfinding.
        /// </summary>
        public int FCost { get { return GCost + HCost; } }

        /// <summary>
        /// The color of the node when drawn in the console.
        /// </summary>
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// The parent of the node, used in AStar pahfinding.
        /// </summary>
        public Node Parent { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Implemented from the IComparable interface.
        /// Compares this Node to another Node based on FCost first, HCost second.
        /// </summary>
        /// <param name="other">A Node to compare to.</param>
        /// <returns>1 if this Node has lower FCost, HCost than other Node.</returns>
        /// <returns>0 if this Node has same FCost, HCost as other Node.</returns>
        /// <returns>-1 if this Node has higher FCost, HCost than other Node.</returns>
        public int CompareTo(Node other)
        {
            int result = other.FCost.CompareTo(FCost); // Compare FCost.

            if (result == 0) // If FCost are same, compare HCost.
            {
                result = other.HCost.CompareTo(HCost);
            }

            return result;
        }
    }
}
