
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Edge<T>
    {
        public Node<T> Start { get; private set; }
        public Node<T> End { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="start">A node.</param>
        /// <param name="end">A node.</param>
        public Edge (Node<T> start, Node<T> end)
        {
            Start = start;
            End = end;
        }
    }
}
