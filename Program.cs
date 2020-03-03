using System;
using Kruskal.Graphs;

namespace Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.AddEdge((1, 2), 1);
            graph.AddEdge((1, 3), 2);
            graph.AddEdge((1, 4), 3);
            graph.AddEdge((2, 3), 4);
            graph.AddEdge((2, 4), 5);
            graph.AddEdge((3, 4), 6);
            graph.GetMST();
            Console.WriteLine("Hello World!");
        }
    }
}
