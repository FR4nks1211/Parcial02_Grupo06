using UnityEngine;
using Exercise5;

namespace Exercise5
{
    public class NodeRender : MonoBehaviour
    {
        [SerializeField] Node node;

        private void OnDrawGizmos() //render the node
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(transform.position, 1f);

            for (int i = 0; i < node.connections.Count; i++)
            {
                if (!node.connections[i].IsValid)
                {
                    continue;
                }

                UnityEditor.Handles.Label(transform.position, name);
                Debug.DrawLine(node.connections[i].node1.transform.position, node.connections[i].node2.transform.position, Color.red, 0f);
            }
        }
    }
}