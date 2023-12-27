using Assets.Scripts;
using Assets.Scripts.MiniGenerator;
using UnityEngine;

namespace Player
{
    public class PlayerMiniGeneratorCaller : MonoBehaviour
    {
        [SerializeField] private Transform placementPoint;

        MiniGeneratorState miniGeneratorState;
        MiniGeneratorFollowController followController;
        WiresCreator wiresCreator;
        ElectricityManager electricityManager;
        Generator miniGeneratorGenerator;

        private void Awake()
        {
            wiresCreator = FindObjectOfType<WiresCreator>();
            electricityManager = FindObjectOfType<ElectricityManager>();
            miniGeneratorState = FindObjectOfType<MiniGeneratorState>();
            miniGeneratorGenerator = miniGeneratorState.GetComponent<Generator>();
            followController = miniGeneratorState.GetComponentInChildren<MiniGeneratorFollowController>();
        }

        public void TryToCall()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }


            CmdCallMiniGenerator(placementPoint.position);
        }

        private void CmdCallMiniGenerator(Vector3 clientPos)
        {
            miniGeneratorGenerator.EnergyOutput.connectedEnergyInput = null;
            followController.Follow(clientPos);
            electricityManager.TransferEnergy();
            wiresCreator.ReCreateWires();

            RpcCallMiniGenerator(clientPos);
        }

        private void RpcCallMiniGenerator(Vector3 followPoint)
        {
            miniGeneratorGenerator.EnergyOutput.connectedEnergyInput = null;
            followController.Follow(followPoint);
            electricityManager.TransferEnergy();
            wiresCreator.ReCreateWires();
        }
    }
}