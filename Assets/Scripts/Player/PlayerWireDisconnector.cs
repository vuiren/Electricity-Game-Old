using Assets.Scripts;
using UnityEngine;

namespace Player
{
    public class PlayerWireDisconnector : MonoBehaviour
    {
        PlayerStats playerStats;
        ElectricityManager electricityManager;
        WiresCreator wiresCreator;
        // Use this for initialization
        void Start()
        {
            playerStats = FindObjectOfType<PlayerStats>();
            electricityManager = FindAnyObjectByType<ElectricityManager>();
            wiresCreator = FindObjectOfType<WiresCreator>();
        }

        // Update is called once per frame
        public void DisconnectWire()
        {
            if (!Input.GetMouseButtonDown(1)) return;

            if (playerStats.energyOutputLookingAt && !playerStats.SelectedOutput)
            {
                playerStats.energyOutputLookingAt.connectedEnergyInput = null;
                electricityManager.TransferEnergy();
                wiresCreator.ReCreateWires();
            }
        }
    }
}