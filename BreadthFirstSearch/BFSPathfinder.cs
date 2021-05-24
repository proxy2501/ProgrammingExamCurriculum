using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace BreadthFirstSearch
{
    public class BFSPathfinder<T>
    {
        private Dictionary<Node<T>, Node<T>> parentByNode = new Dictionary<Node<T>, Node<T>>();
        private Queue<Edge<T>> pending = new Queue<Edge<T>>();

        /// <summary>
        /// Performs a DFS search to find a path from start node to goal node.
        /// </summary>
        /// <param name="start">A node.</param>
        /// <param name="goal">A node.</param>
        /// <returns>A list of nodes that map the discovered path. Null if no path found.</returns>
        public List<Node<T>> GetPath(Node<T> start, Node<T> goal)
        {
            parentByNode.Clear();
            pending.Clear();
            pending.Enqueue(new Edge<T>(start, start));
            parentByNode.Add(start, start);

            while (pending.Count != 0)
            {
                Edge<T> current = pending.Dequeue();

                if (current.End == goal) // If goal reached, backtrack and return path.
                    return BacktrackPath(goal, start);

                foreach (Edge<T> edge in current.End.Edges)
                {
                    if (parentByNode.ContainsKey(edge.End)) // If node is DISCOVERED, skip.
                        continue;

                    parentByNode.Add(edge.End, edge.Start);
                    pending.Enqueue(edge);
                }
            }

            return null;
        }

        /// <summary>
        /// Traces the path taken from start to end and returns it.
        /// </summary>
        /// <param name="start">The node to backtrack towards.</param>
        /// <param name="end">The node to backtrack from.</param>
        /// <returns>A list of nodes.</returns>
        private List<Node<T>> BacktrackPath(Node<T> end, Node<T> start)
        {
            List<Node<T>> path = new List<Node<T>>();

            path.Add(end);

            while (path.Last() != start)
            {
                path.Add(parentByNode[path.Last()]);
            }

            path.Reverse();

            return path;
        }
    }
}
