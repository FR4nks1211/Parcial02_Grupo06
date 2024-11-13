using System.Collections.Generic;
using UnityEngine;

namespace Exercise5
{
    public class Pathfinder : MonoBehaviour
    {
        [SerializeField] private Graph graph;

        public List<Path> paths;

        private List<Edge> exploredConnections = new List<Edge>();
        private List<Edge> connectionsToTravel = new List<Edge>();

        public Path RequestPath()
        {
            Path shortestPath = SearchPath(); //i save this so i can print them before exiting the loop
            PrintPaths();

            return shortestPath;
        }

        Path SearchPath()
        {
            Node currentNode = graph.startNode; //aka root node

            bool allPathsFromRootSearched = false;

            while (!allPathsFromRootSearched)
            {
                bool allNeighboursExplored = true;

                for (int i = 0; i < currentNode.connections.Count; i++)
                {
                    Edge connection = currentNode.connections[i];

                    if (!IsNewConnection(connection))
                    {
                        currentNode = NextNode(connection);

                        if (connection.node2 == graph.endNode)
                        {
                            CreatePath(connectionsToTravel);
                            currentNode = PreviousNode(connection);
                        }

                        allNeighboursExplored = false;

                        break;
                    }
                }

                if (allNeighboursExplored)
                {
                    allPathsFromRootSearched = currentNode == graph.startNode;

                    if (!allPathsFromRootSearched)
                    {
                        currentNode = PreviousNode(connectionsToTravel[^1]);
                    }
                }
            }

            return CalculateShortestPath(paths);
        }

        Node NextNode(Edge connection)
        {
            connectionsToTravel.Add(connection);
            exploredConnections.Add(connection);

            return connection.node2;
        }

        Node PreviousNode(Edge connection)
        {
            Node node = connectionsToTravel[^1].node1;
            connectionsToTravel.Remove(connection);

            return node;
        }

        void CreatePath(List<Edge> connections)
        {
            paths.Add(new Path(connections));
        }

        bool IsNewConnection(Edge connection)
        {
            for (int i = 0; i < exploredConnections.Count; i++)
            {
                if (connection.IsEqual(exploredConnections[i]) || connection.IsReverse(exploredConnections[i]))
                {
                    return true;
                }
            }

            return false;
        }

        Path CalculateShortestPath(List<Path> paths)
        {
            if (paths.Count <= 0)
            {
                return null;
            }

            Path shortestPath = paths[0]; //default, gets picked if are all equal

            for (int i = 0; i < paths.Count; i++)
            {
                if(paths[i].weight < shortestPath.weight)
                {
                    shortestPath = paths[i];
                }
            }

            return shortestPath;
        }


        //RENDERING STUFF


        void PrintPaths()
        {
            if (paths.Count <= 0)
            {
                Debug.Log("No path found");
                return;
            }

            for (int i = 0; i < paths.Count; i++)
            {
                Debug.Log("Path Found: "+FormatPath(paths[i]));
            }

            Path shortestPath = CalculateShortestPath(paths);

            Debug.Log("Shortest Path: "+FormatPath(shortestPath));
        }

        string FormatPath(Path path)
        {
            string pathText = "";

            for (int i = 0; i < path.connections.Count; i++)
            {
                pathText += "("+path.connections[i].node1.gameObject.name+","+path.connections[i].node2.gameObject.name+")" + ", ";
            }

            return pathText;
        }
    }
}