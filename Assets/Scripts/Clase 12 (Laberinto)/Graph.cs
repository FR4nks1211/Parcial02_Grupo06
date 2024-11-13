using System.Collections.Generic;
using UnityEngine;

namespace Exercise5
{
    public class Graph : MonoBehaviour
    {
        public Node startNode;
        public Node endNode;
        [Space]
        public List<Node> nodes;

        void Awake()
        {
            GetNodes();
        }

        void GetNodes()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Node node = transform.GetChild(i).gameObject.GetComponent<Node>();

                node.gameObject.name = i.ToString();
                nodes.Add(node);
            }
        }
    }
}