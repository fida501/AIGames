using System.Collections.Generic;
using UnityEngine;

namespace T5_BehaviourTree
{
    public class T5_Patrol : T5_Tree
    {
        public List<Transform> patrolPoints;
        public float speed = 2f;

        protected override Node SetupTree()
        {
            List<Node> patrolNodes = new List<Node>();
            foreach (Transform point in patrolPoints)
            {
                patrolNodes.Add(new T5_Sequence(new List<Node>
                {
                    new T5_MoveTo(point, speed),
                    new T5_CheckDistance(point)
                }));
            }
            return new T5_Selector(patrolNodes);
        }
    }
}