using Mirror;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
    public class PlayerStats : NetworkBehaviour
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            syncDirection = SyncDirection.ClientToServer;
        }

        public EnergyInput energyInputLookingAt;
        public EnergyOutput energyOutputLookingAt;

        public IInteractable interactableLookingAt;
        public PlayerToolEnum currentPlayerTool;

        private EnergyOutput selectedOutput;
        public RaycastHit latestLookAtHit;

        public Vector3 moveVector;

        public Elevator elevatorPlayerIn;

        [SyncVar]
        public int dvoiniksCount = 2;
        [SyncVar]
        public bool moving;
        [SyncVar]
        public bool creatingWire;

        public EnergyOutput SelectedOutput { get => selectedOutput; set => selectedOutput = value; }

        public UnityEvent OnOutputSelection;
    }
}