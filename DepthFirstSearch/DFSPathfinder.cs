using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace DepthFirstSearch
{
    public class DFSPathfinder<T>
    {
        private Dictionary<Node<T>, Node<T>> parentByNode = new Dictionary<Node<T>, Node<T>>();
        private Stack<Edge<T>> pending = new Stack<Edge<T>>();

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
            pending.Push(new Edge<T>(start, start));

            while (pending.Count != 0)
            {
                Edge<T> current = pending.Pop();

                if (parentByNode.ContainsKey(current.End)) // If node is VISITED, skip.
                    continue;

                parentByNode.Add(current.End, current.Start);

                if (current.End == goal) // If goal reached, backtrack and return path.
                    return BacktrackPath(goal, start);

                foreach (Edge<T> edge in current.End.Edges)
                {
                    pending.Push(edge);
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
