using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Node<T>
    {
        public List<Edge<T>> Edges { get; private set; } = new List<Edge<T>>();
        public T Data { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The data that node should hold.</param>
        public Node(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Adds an edge to end node. Can specify if directional.
        /// </summary>
        /// <param name="end">A node.</param>
        /// <param name="directed">A bool indicating whether edge is diractional or not.</param>
        public void AddEdge(Node<T> end, bool directed = false)
        {
            Edges.Add(new Edge<T>(this, end));

            if (!directed)
            {
                end.AddEdge(this, true);
            }
        }

        /// <summary>
        /// Removes an edge to end node.
        /// </summary>
        /// <param name="end">A node.</param>
        public void RemoveEdge(Node<T> end)
        {
            Edges.Remove(Edges.Find(e => e.End.Equals(end)));
        }
    }
}
