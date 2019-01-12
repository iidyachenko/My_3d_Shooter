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

        void Start()
        {
            agend = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agend.updateRotation = false;
            agend.updateRotation = true;
        }

        void Update()
        {
            if (agend.remainingDistance > agend.stoppingDistance)
                character.Move(agend.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }

        public void SetDestination(Vector3 pos)
        {
            NavMeshHit hit;
            if(NavMesh.SamplePosition(pos,out hit,20f,-1))
            {
                agend.SetDestination(hit.position);
            }
            else
            {
                Debug.Log("Wrong position");
            }
        }
    }
}
