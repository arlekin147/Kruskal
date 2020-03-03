using System.Collections.Generic;
using System.Linq;

namespace Kruskal.Graphs
{
    public class Graph
    {
        private SortedSet<Edge> _edges = new SortedSet<Edge>();

        private HashSet<Vertex> _vertexes = new HashSet<Vertex>();

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
                if (!_vertexes.Contains(vertex1)) _vertexes.Add(vertex1);
                if (!_vertexes.Contains(vertex2)) _vertexes.Add(vertex2);
                _edges.Add(edgeOfGraph);
                _vertexes.Where(v => v.Number == edgeOfGraph.NumbersOfVertex.Item1).First().Edges.Add(edgeOfGraph);
                _vertexes.Where(v => v.Number == edgeOfGraph.NumbersOfVertex.Item2).First().Edges.Add(edgeOfGraph);
            }
        }

        public Graph GetMST()
        {
            var components = new HashSet<HashSet<Vertex>>();

            foreach (var vertex in _vertexes)
            {
                var component = new HashSet<Vertex>();
                component.Add(new Vertex(vertex.Number));

                components.Add(new HashSet<Vertex>(component));
            }

            var result = new Graph();

            foreach (var edge in _edges)
            {
                var firstComponent = components.Where(c => c.Contains(new Vertex(edge.NumbersOfVertex.Item1))).First();
                var secondComponent = components.Where(c => c.Contains(new Vertex(edge.NumbersOfVertex.Item2))).First();

                if (!firstComponent.SequenceEqual(secondComponent))
                {
                    components.RemoveWhere(c => c.Contains(new Vertex(edge.NumbersOfVertex.Item1)) ||
                                                c.Contains(new Vertex(edge.NumbersOfVertex.Item2)));
                    components.Add(firstComponent.Union(secondComponent).ToHashSet());
                    result.AddEdge(edge);
                }
            }
            return result;
        }
    }
}