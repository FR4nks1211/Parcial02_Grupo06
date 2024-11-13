using System.Collections.Generic;
using UnityEngine;

namespace Exercise5
{
    public class Node : MonoBehaviour
    {
        public List<Edge> connections;

        public Node(List<Edge> connections)
        {
            this.connections = connections;
        }

        void Awake() //create edge so it works both ways
        {
            for (int i = 0; i < connections.Count; i++)
            {
                connections[i].node2.connections.Add(new Edge(connections[i].node2, connections[i].node1, connections[i].weight));
            }
        }
    }
}