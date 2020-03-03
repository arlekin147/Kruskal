using System.Collections.Generic;
using System.Linq;
using DisjoinSet;

namespace Kruskal.Graphs
{
    public class Graph
    {
        private HashSet<Edge> _edges = new HashSet<Edge>();

        private MyDisjoinSet _vertexes = new MyDisjoinSet();

        public void AddEdge((int, int) edge, int weight)
        {
            var edgeOfGraph = new Edge(edge, weight);
            AddEdge(edgeOfGraph);
        }

        private void AddEdge(Edge edgeOfGraph)
        {
            if (!_edges.Contains(edgeOfGraph))
            {
                var vertex1 = new Vertex(edgeOfGraph.NumbersOfVertex.Item1);
                var vertex2 = new Vertex(edgeOfGraph.NumbersOfVertex.Item2);
                if (!_vertexes.Contains(edgeOfGraph.NumbersOfVertex.Item1)) _vertexes.Add(edgeOfGraph.NumbersOfVertex.Item1);
                if (!_vertexes.Contains(edgeOfGraph.NumbersOfVertex.Item2)) _vertexes.Add(edgeOfGraph.NumbersOfVertex.Item2);
                _edges.Add(edgeOfGraph);
            }
        }

        public Graph GetMST()
        {
            var result = new Graph();

            foreach (var edge in _edges)
            {
                var firstComponent = _vertexes.Find(edge.NumbersOfVertex.Item1);
                var secondComponent = _vertexes.Find(edge.NumbersOfVertex.Item2);

                if (firstComponent != secondComponent)
                {
                    _vertexes.Union(firstComponent, secondComponent);
                    result.AddEdge(edge);
                }
            }
            return result;
        }
    }
}