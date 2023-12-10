using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] private Transform[] elevatorPositions;
        [SerializeField] private Transform root;
        public float moveSpeed = 2f;
        public bool moving;

        public Vector3 moveVector;
        public float playerHeight = 1f;

        private int elevatorIndex;
        public List<Transform> playersInElevator = new();

        private void Update()
        {
            var destination = elevatorPositions[elevatorIndex];
            var distance = Vector3.Distance(destination.position, root.position);
            moving = distance > 0.1;
            if (!moving)
            {
                return;
            }
            var direction = root.position.y > destination.position.y ? Vector3.down : Vector3.up;
            moveVector = moveSpeed * Time.deltaTime * direction;
        }

        private void LateUpdate()
        {
            if (!moving) return;

            foreach (var player in playersInElevator)
            {
                player.position = new Vector3(player.position.x, root.position.y + moveVector.y + playerHeight, player.position.z);
            }
            root.Translate(moveVector);
        }

        public void ToggleElevator(int index)
        {
            elevatorIndex = index;
        }
    }
}