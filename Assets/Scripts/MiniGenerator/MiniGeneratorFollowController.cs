using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.MiniGenerator
{
    public class MiniGeneratorFollowController : MonoBehaviour
    {
        [SerializeField] private MiniGeneratorState generatorState;
        [SerializeField] protected Transform generator;
        [SerializeField] protected NavMeshAgent agent;
        const float error = 1f;

        public void Follow(Vector3 followPoint)
        {
            agent.SetDestination(followPoint);
            generatorState.moving = true;
        }

        void FixedUpdate()
        {
            if (!generatorState.moving)
            {
                return;
            }

            var distance = Vector3.Distance(generator.position, agent.destination);
            if (distance < error)
            {
                generatorState.moving = false;
            }
            else
            {
                generatorState.moving = true;

                if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
                {
                    generatorState.moving = false;
                }
            }

        }
    }
}