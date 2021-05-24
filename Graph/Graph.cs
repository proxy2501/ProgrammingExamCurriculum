using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; private set; } = new List<Node<T>>();

        /// <summary>
        /// Tests whether there is an edge from start node to end node.
        /// </summary>
        /// <param name="start">A node.</param>
        /// <param name="end">A node.</param>
        /// <returns>´True if there is an edge going from start node to end node.</returns>
        public bool Adjacent(Node<T> start, Node<T> end)
        {
            return start.Edges.Any(e => e.End.Equals(end));
        }

        /// <summary>
        /// Lists all other nodes to which input node has an edge.
        /// </summary>
        /// <param name="node">A node.</param>
        /// <returns>A list of nodes that are adjecent from input node.</returns>
        public List<Node<T>> Neighbors(Node<T> node)
        {
            List<Node<T>> neighbors = new List<Node<T>>();

            foreach (Edge<T> edge in node.Edges)
            {
                neighbors.Add(edge.End);
            }

            return neighbors;
        }

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="newNode">A node.</param>
        /// <returns>The same node that was added.</returns>
        public Node<T> AddNode(Node<T> newNode)
        {
            if (Nodes.Contains(newNode))
                throw new ArgumentException("Graph already contains the node.");

            Nodes.Add(newNode);
            return newNode;
        }

        /// <summary>
        /// removes a node from the graph.
        /// </summary>
        /// <param name="nodeToRemove">A node.</param>
        public void RemoveNode(Node<T> nodeToRemove)
        {
            if (!Nodes.Contains(nodeToRemove))
                throw new ArgumentException("Graph does not contain the node.");

            Nodes.Remove(nodeToRemove);

            foreach (Node<T> otherNode in Nodes)
            {
                otherNode.RemoveEdge(nodeToRemove);
            }
        }

        /// <summary>
        /// Adds an edge from start to end node. Can specify if directional.
        /// </summary>
        /// <param name="start">A node.</param>
        /// <param name="end">A node.</param>
        /// <param name="directed">A bool indicating whether edge is diractional or not.</param>
        public void AddEdge(Node<T> start, Node<T> end, bool directed = true)
        {
            if (!Adjacent(start, end))
                start.AddEdge(end);

            if (!directed)
                end.AddEdge(start);
        }

        /// <summary>
        /// Removes an edge from start to end node.
        /// </summary>
        /// <param name="start">A node.</param>
        /// <param name="end">A node.</param>
        public void RemoveEdge(Node<T> start, Node<T> end)
        {
            start.RemoveEdge(end);
        }

        /// <summary>
        /// Gets the value associated with the node.
        /// </summary>
        /// <param name="node">A node.</param>
        /// <returns>The value associated with the node.</returns>
        public T GetNodeValue(Node<T> node)
        {
            return node.Data;
        }

        /// <summary>
        /// Sets the value associated with the node.
        /// </summary>
        /// <param name="node">A node.</param>
        public void SetNodeValue(Node<T> node, T value)
        {
            node.Data = value;
        }
    }
}
