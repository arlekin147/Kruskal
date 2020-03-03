using System.Collections.Generic;

namespace Kruskal.Graphs
{
    internal class Vertex
    {
        public Vertex(int number)
        {
            Number = number;
        }
        public int Number { get; }
        public SortedSet<Edge> Edges { get; } = new SortedSet<Edge>();

        public override bool Equals(object obj)
        {
            var vertex = obj as Vertex;
            if (vertex is null) return false;

            return Number == vertex.Number;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}