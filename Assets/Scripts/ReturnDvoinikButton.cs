using Mirror;
using UnityEngine;

namespace Assets.Scripts
{
    public class ReturnDvoinikButton : NetworkBehaviour, IInteractable
    {
        [SerializeField] private GameObject dvoinik;
        [SerializeField] private Renderer buttonRenderer;

        WiresCreator wiresCreator;
        ElectricityManager electricityManager;

        private void Awake()
        {
            wiresCreator = FindObjectOfType<WiresCreator>();
            electricityManager = FindObjectOfType<ElectricityManager>();
        }

        public void Interact(GameObject interactor)
        {
            DestroyDvoinik();
        }

        public GameObject InteractableGameObject()
        {
            return dvoinik;
        }

        [Server]
        void DestroyDvoinik()
        {
            print("destroying " + dvoinik.name);

            var dvoinikInput = dvoinik.GetComponentInChildren<EnergyInput>();

            var allEnergyOutputs = FindObjectsOfType<EnergyOutput>();
            foreach( var energyOutput in allEnergyOutputs )
            {
                if(energyOutput.connectedEnergyInput == dvoinikInput )
                {
                    energyOutput.connectedEnergyInput = null;
                    break;
                }
            }

            var outputs = dvoinik.GetComponentsInChildren<EnergyOutput>();
            foreach (var output in outputs)
            {
                output.connectedEnergyInput = null;
            }
            NetworkServer.Destroy(dvoinik);
            wiresCreator.ReCreateWires();
            electricityManager.TransferEnergy();
            RpcRecreateWires();
        }

        [ClientRpc]
        void RpcRecreateWires()
        {
            var outputs = dvoinik.GetComponentsInChildren<EnergyOutput>();
            foreach (var output in outputs)
            {
                output.connectedEnergyInput = null;
            }
            wiresCreator.ReCreateWires();
            electricityManager.TransferEnergy();
        }

        public Renderer RendererToVisualizeAt()
        {
            return buttonRenderer;
        }

        public bool ReturnDvoinikToPlayer()
        {
            return true;
        }
    }
}