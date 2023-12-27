using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public EnergyInput energyInputLookingAt;
        public EnergyOutput energyOutputLookingAt;

        public IInteractable interactableLookingAt;
        public PlayerToolEnum currentPlayerTool;

        private EnergyOutput selectedOutput;
        public RaycastHit latestLookAtHit;

        public Vector3 moveVector;

        public Elevator elevatorPlayerIn;

        public int dvoiniksCount = 2;
        public bool moving;
        public bool creatingWire;

        public EnergyOutput SelectedOutput { get => selectedOutput; set => selectedOutput = value; }

        public UnityEvent OnOutputSelection;
    }
}