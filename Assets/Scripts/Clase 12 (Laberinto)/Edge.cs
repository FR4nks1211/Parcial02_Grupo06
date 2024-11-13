using System;

namespace Exercise5
{
    [Serializable]
    public class Edge
    {
        public int weight = 1;

        public Node node1;
        public Node node2;

        public bool IsValid => node1 != node2 && node1 != null && node2 != null;

        public bool IsEqual(Edge edge)
        {
            return node1 == edge.node1 && node2 == edge.node2;
        }

        public bool IsReverse(Edge edge)
        {
            return node1 == edge.node2 && node2 == edge.node1;
        }

        public Edge(Node node1, Node node2, int weight)
        {
            this.node1 = node1;
            this.node2 = node2;
            this.weight = weight;
        }
    }
}