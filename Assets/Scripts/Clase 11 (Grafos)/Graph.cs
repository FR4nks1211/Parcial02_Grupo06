using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Connection 
{
    public string Destination { get; set; }
    public int Cost {get; set; }

    public Connection(string destination, int cost)
    {
        Destination = destination;
        Cost = cost;
    }
}

public class Graph
{
    public Dictionary<string, List<Connection>> nodes;

    public Graph()
    {
        nodes = new Dictionary<string, List<Connection>>();
    }

    public void AddNode(string name)
    {  
        if (!nodes.ContainsKey(name))
        {
            nodes[name] = new List<Connection>();
        }
    }

    public void AddConnection(string from, string to, int cost)
    {
        if (nodes.ContainsKey(from) && nodes.ContainsKey(to))
        {
            nodes[from].Add(new Connection(to, cost));
            nodes[to].Add(new Connection(from, cost));
        }
    }
}
