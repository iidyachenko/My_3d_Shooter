using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace FPS
{
    public class TeammateModel : MonoBehaviour
    {
        private NavMeshAgent agend;
        private ThirdPersonCharacter character;
        private Queue<NavMeshHit> destinations;

        void Start()
        {
            agend = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            destinations = new Queue<NavMeshHit>();
            agend.updateRotation = false;
            agend.updateRotation = true;
        }

        void Update()
        {
            if (agend.remainingDistance > agend.stoppingDistance)
                character.Move(agend.desiredVelocity, false, false);
            else if (destinations.Count > 0)
                SetDestination(destinations.Dequeue());
            else character.Move(Vector3.zero, false, false);
        }

        public void AddDestination(Vector3 pos)
        {                       
            NavMeshHit hit;
            if (NavMesh.SamplePosition(pos, out hit, 20f, -1))
            {
                destinations.Enqueue(hit);
                Debug.Log(destinations.Count);
            }
            else
            {
                Debug.Log("Wrong position");
            }
        }

        public void SetDestination(NavMeshHit hit)
        {
                agend.SetDestination(hit.position);
        }
    }
}
