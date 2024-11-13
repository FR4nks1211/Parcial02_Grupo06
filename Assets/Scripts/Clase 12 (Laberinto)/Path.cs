using System;
using System.Collections.Generic;

namespace Exercise5
{
    [Serializable]
    public class Path
    {
        public List<Edge> connections;
        public int weight = 0;

        public Path(List<Edge> connections)
        {
            this.connections = new List<Edge>(connections);
            weight = CalculateWeight();
        }

        public int CalculateWeight()
        {
            int weight = 0;

            for (int i = 0; i < connections.Count; i++)
            {
                weight += connections[i].weight;
            }

            return weight;
        }
    }
}