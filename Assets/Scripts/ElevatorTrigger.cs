using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Assets.Scripts
{
    public class ElevatorTrigger : MonoBehaviour
    {
        [SerializeField] private Elevator elevator;
        private void OnTriggerEnter(Collider other)
        {
            print("enter " + other.name);

            elevator.playersInElevator.Add(other.transform);
            var playerStats = other.GetComponentInParent<PlayerStats>();
            var playerSettings = other.GetComponentInParent<PlayerSettings>();
            elevator.playerHeight = playerSettings.playerHeight;
            playerStats.elevatorPlayerIn = elevator;
        }

        private void OnTriggerExit(Collider other)
        {
            print("exit: " + other.name);
            elevator.playersInElevator.Remove(other.transform);
            var playerStats = other.GetComponentInParent<PlayerStats>();
            playerStats.elevatorPlayerIn = null;
        }
    }
}