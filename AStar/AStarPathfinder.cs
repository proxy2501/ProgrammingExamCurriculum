using System;
using System.Collections.Generic;
using System.Threading;

namespace AStar
{
    public class AStarPathfinder
    {
        private Grid grid; // The grid on which the pathfinder operates.
        private int orthogonalCost = 10; // The cost of moving horizontally or vertically.
        private int diagonalCost = 14; // The cost of moving diagonally.

        /// <summary>
        /// Instructs the pathfinder to avoid or allow diagonal movement.
        /// </summary>
        public bool DiagonalMovementAllowed { get; set; } = true;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="grid">A Grid for this pathfinder to operate on.</param>
        public AStarPathfinder(Grid grid)
        {
            this.grid = grid;
        }

        /// <summary>
        /// Finds and draws a path between two nodes using the A* algorithm.
        /// </summary>
        /// <param name="start">A Node to start the search from.</param>
        /// <param name="end">A Node to serve as the goal of the search.</param>
        public void FindPath(Node start, Node end)
        {
            Heap<Node> openList = new Heap<Node>(grid.Nodes.Length); // Heap is self-sorting with high efficiency.
            HashSet<Node> closedList = new HashSet<Node>(); // HashSet.Contains has complexity of O(1), disallows duplicates.

            openList.Add(start);

            while (openList.Count() > 0)
            {
                Node currentNode = openList.PopFirst();

                closedList.Add(currentNode);

                if (currentNode == end)
                {
                    RetracePath(start, end);
                    return;
                }

                foreach (Node adjacentNode in grid.GetAdjacentNodes(currentNode, DiagonalMovementAllowed))
                {
                    // Skip unwalkable nodes or nodes that have already been visited.
                    if (!adjacentNode.Walkable || closedList.Contains(adjacentNode)) continue;

                    // Calculate the GCost of moving to the adjacent node through current node.
                    int newGCost = currentNode.GCost + CalculateHCost(currentNode, adjacentNode);

                    if (newGCost < adjacentNode.GCost || !openList.Contains(adjacentNode))
                    {
                        adjacentNode.GCost = newGCost;
                        adjacentNode.HCost = CalculateHCost(adjacentNode, end);
                        adjacentNode.Parent = currentNode;

                        if (!openList.Contains(adjacentNode))
                        {
                            openList.Add(adjacentNode);
                        }
                        else
                        {
                            openList.UpdateItem(adjacentNode);
                        }
                    }

                    if (adjacentNode != end)
                    {
                        adjacentNode.Color = ConsoleColor.Yellow;
                        Thread.Sleep(1);
                        Program.UpdateUI();
                    }
                }
            }
        }

        /// <summary>
        /// Retraces and colors the path between start and end nodes.
        /// </summary>
        /// <param name="start">A Node.</param>
        /// <param name="end">A Node.</param>
        private void RetracePath(Node start, Node end)
        {
            Node current = end;
            while (current != start)
            {
                current = current.Parent;
                if (current != start)
                {
                    current.Color = ConsoleColor.DarkMagenta;
                }
            }

            Program.UpdateUI();
        }

        /// <summary>
        /// Calculates the cost of moving bewteen two nodes on the grid, assuming no obstacles.
        /// </summary>
        /// <param name="nodeA">The origin node.</param>
        /// <param name="nodeB">The destination node.</param>
        /// <returns>The calculated movement cost.</returns>
        private int CalculateHCost(Node nodeA, Node nodeB)
        {
            int distanceX = Math.Abs(nodeA.X - nodeB.X);
            int distanceY = Math.Abs(nodeA.Y - nodeB.Y);

            if (!DiagonalMovementAllowed)
            {
                return (distanceX + distanceY) * orthogonalCost;
            }
            else
            {
                if (distanceX > distanceY)
                {
                    return distanceY * diagonalCost + (distanceX - distanceY) * orthogonalCost;
                }
                else
                {
                    return distanceX * diagonalCost + (distanceY - distanceX) * orthogonalCost;
                }
            }
        }
    }
}
