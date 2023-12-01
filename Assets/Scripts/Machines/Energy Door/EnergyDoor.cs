using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Machines
{
    [RequireComponent(typeof(Machine), typeof(EnergyDoorState))]
    public class EnergyDoor : MonoBehaviour
    {
        [SerializeField] private Animator doorAnimator;
        [SerializeField] private Collider doorCollider;
        const float error = 0.04f;
        Machine machine;
        EnergyDoorState energyDoorState;
        NavMeshObstacle meshObstacle;

        private void Awake()
        {
            machine = GetComponent<Machine>();
            energyDoorState = GetComponent<EnergyDoorState>();
            meshObstacle = GetComponent<NavMeshObstacle>();
        }

        private void Update()
        {
            doorAnimator.SetBool("Opened", energyDoorState.opened);
            doorCollider.enabled = !energyDoorState.opened;
            meshObstacle.enabled = !energyDoorState.opened;
        }

        public void Open()
        {
            if (Mathf.Abs(machine.EnergyStored - machine.EnergyConsumption) <= error)
            {
                energyDoorState.opened = true;
            }
        }

        public void Close()
        {
            if (Mathf.Abs(machine.EnergyStored - machine.EnergyConsumption) <= error)
            {
                energyDoorState.opened = false;
            }
        }

        public void ToggleDoor()
        {
            if (energyDoorState.opened)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }
}