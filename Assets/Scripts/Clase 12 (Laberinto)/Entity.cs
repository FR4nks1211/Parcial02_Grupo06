using UnityEngine;

namespace Exercise5
{
    public class Entity : MonoBehaviour //quick code for finding path that prob violates a lot of coding principles but whatever i don't make AI
    {
        [SerializeField] private Transform _Transform;
        [Space]
        [SerializeField] private Pathfinder pathFinder;
        [SerializeField] private float moveSpeed;

        public Path currentPath;

        public int connectionTravelling = 0;

        void Start()
        {
            currentPath = pathFinder.RequestPath();

            if (currentPath == null || currentPath.connections.Count <= 0)
            {
                enabled = false;
                return;
            }

            transform.position = currentPath.connections[0].node1.transform.position;
        }

        void Update()
        {
            if (currentPath.connections.Count - 1 < connectionTravelling)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, currentPath.connections[connectionTravelling].node2.transform.position, moveSpeed * Time.deltaTime); 

            if (Vector3.Distance(transform.position, currentPath.connections[connectionTravelling].node2.transform.position) <= 0.001f) //floats are not precise so just in case
            {
                connectionTravelling += 1;
            }
        }
    }
}