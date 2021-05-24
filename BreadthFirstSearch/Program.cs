using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;

namespace BreadthFirstSearch
{
    class Program
    {
        private static BFSPathfinder<string> pathfinder = new BFSPathfinder<string>();

        static void Main(string[] args)
        {
            #region Create Graph
            Graph<string> graph = new Graph<string>();

            Node<string> entrance = graph.AddNode(new Node<string>("Entrance"));
            Node<string> iceblaster = graph.AddNode(new Node<string>("Ice Blaster"));
            Node<string> slotmachine = graph.AddNode(new Node<string>("Slot Machines"));
            Node<string> funhouse = graph.AddNode(new Node<string>("Funhouse"));
            Node<string> rocketships = graph.AddNode(new Node<string>("Rocket Ships"));
            Node<string> cinema = graph.AddNode(new Node<string>("3D Cinema"));
            Node<string> pirateship = graph.AddNode(new Node<string>("Pirate Ship"));
            Node<string> hotdogs = graph.AddNode(new Node<string>("Hotdogs"));
            Node<string> logflume = graph.AddNode(new Node<string>("Log Flume"));
            Node<string> bigdipper = graph.AddNode(new Node<string>("Big Dipper"));
            Node<string> ghosttrain = graph.AddNode(new Node<string>("Ghost Train"));
            Node<string> rollercoaster = graph.AddNode(new Node<string>("Rollercoaster"));
            Node<string> carousel = graph.AddNode(new Node<string>("Carousel"));
            Node<string> flyingchairs = graph.AddNode(new Node<string>("Flying Chairs"));

            graph.AddEdge(entrance, slotmachine);
            graph.AddEdge(entrance, iceblaster);
            graph.AddEdge(entrance, funhouse);

            graph.AddEdge(slotmachine, rocketships);
            graph.AddEdge(slotmachine, hotdogs);

            graph.AddEdge(iceblaster, slotmachine);
            graph.AddEdge(iceblaster, rocketships);
            graph.AddEdge(iceblaster, funhouse);
            graph.AddEdge(iceblaster, cinema);

            graph.AddEdge(funhouse, cinema);

            graph.AddEdge(hotdogs, logflume);

            graph.AddEdge(logflume, bigdipper);

            graph.AddEdge(bigdipper, rollercoaster);
            graph.AddEdge(bigdipper, ghosttrain);

            graph.AddEdge(ghosttrain, carousel);
            graph.AddEdge(ghosttrain, flyingchairs);
            graph.AddEdge(ghosttrain, rocketships);

            graph.AddEdge(carousel, flyingchairs);

            graph.AddEdge(cinema, rocketships);
            graph.AddEdge(cinema, pirateship);
            #endregion

            List<Node<string>> path = pathfinder.GetPath(entrance, carousel);

            if (path == null)
            {
                Console.WriteLine("No path found.");
            }
            else
            {
                foreach (Node<string> node in path)
                {
                    Console.WriteLine(node.Data.ToString());
                }
            }

            Console.ReadKey();
        }
    }
}
