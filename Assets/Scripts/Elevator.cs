using Assets.Scripts.Player;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] private Transform root, bottomPosition, topPoisition;
        public float moveSpeed = 2f;
        public ElevatorPositionEnum ElevatorPosition;
        public bool moving;

        public Vector3 moveVector;
        public float playerHeight = 1f;

        public List<Transform> playersInElevator = new();

        private void Update()
        {
            var destination = ElevatorPosition == ElevatorPositionEnum.Bottom ? bottomPosition : topPoisition;
            moving = Vector3.Distance(destination.position, root.position) > 0.1;

            if (!moving) return;
            moveVector = ElevatorPosition == ElevatorPositionEnum.Bottom ? Vector3.down * moveSpeed : Vector3.up * moveSpeed;
            moveVector *= moveSpeed * Time.deltaTime;
        }

        private void LateUpdate()
        {
            if (!moving) return;

            foreach(var player in playersInElevator)
            {
                player.position = new Vector3(player.position.x, root.position.y + moveVector.y + playerHeight, player.position.z);
            }
            root.Translate(moveVector);
        }

        [Button]
        public void ToggleElevator()
        {
            ElevatorPosition = ElevatorPosition == ElevatorPositionEnum.Bottom ? ElevatorPositionEnum.Top : ElevatorPositionEnum.Bottom;
        }
    }
}