using System;
using System.Diagnostics.CodeAnalysis;

namespace Kruskal.Graphs
{
    internal class Edge : IComparable<Edge>
    {
        public Edge((int, int) numbersOfVertex, int weight)
        {
            NumbersOfVertex = numbersOfVertex;
            Weight = weight;
        }
        public (int, int) NumbersOfVertex { get; }

        public int Weight { get; }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }

        public override bool Equals(object other)
        {
            var otherEdge = other as Edge;
            if (otherEdge is null) return false;

            return (NumbersOfVertex.Item1 == otherEdge.NumbersOfVertex.Item1 &&
                   NumbersOfVertex.Item2 == otherEdge.NumbersOfVertex.Item2) ||
                   (NumbersOfVertex.Item1 == otherEdge.NumbersOfVertex.Item2 &&
                   NumbersOfVertex.Item2 == otherEdge.NumbersOfVertex.Item1);
        }

        public override int GetHashCode()
        {
            return NumbersOfVertex.GetHashCode();
        }
    }
}