using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using QFSW.QC;
using UnityEngine;

namespace Player
{
    public class PlayerWireCreator : MonoBehaviour, IRootReader
    {
        PlayerStats playerStats;
        WiresCreator wireManager;
        ElectricityManager electricityManager;

        [SerializeField] LineRenderer wirePreview;

        private readonly List<Vector3> normals = new();

        // Use this for initialization
        void Start()
        {
            electricityManager = FindObjectOfType<ElectricityManager>();
            wireManager = FindObjectOfType<WiresCreator>();
            wirePreview.positionCount = 1;
            playerStats.OnOutputSelection.AddListener(StartDrawingWire);
        }

        public void ReadRoot(GameObject root)
        {
            playerStats = root.GetComponentInChildren<PlayerStats>();
        }

        private void StartDrawingWire()
        {
            if (!playerStats.SelectedOutput) return;
            wirePreview.positionCount = 2;
            wirePreview.SetPosition(0, playerStats.SelectedOutput.transform.position);
            wirePreview.SetPosition(1, playerStats.SelectedOutput.transform.position);
            normals.Clear();
        }

        // Update is called once per frame
        public void HandleWireCreation()
        {
            if (Input.GetMouseButtonDown(0)) HandleLMBClick();
            if (Input.GetMouseButtonDown(1)) HandleRMBClick();

            if (playerStats.SelectedOutput)
            {
                wirePreview.SetPosition(wirePreview.positionCount - 1, playerStats.latestLookAtHit.point);
            }
        }

        private void HandleRMBClick()
        {
            if (!playerStats.SelectedOutput) return;
            wirePreview.SetPosition(wirePreview.positionCount - 1, playerStats.latestLookAtHit.point);
            wirePreview.positionCount++;
            normals.Add(playerStats.latestLookAtHit.normal);
        }

        private void HandleLMBClick()
        {
            var canCreateWire = playerStats.SelectedOutput && playerStats.energyInputLookingAt;
            if (canCreateWire)
            {
                CreateWire();
            }

            wirePreview.positionCount = 0;
            playerStats.SelectedOutput = null;
            playerStats.creatingWire = false;
        }

        private void CreateWire()
        {
            var wirePositions = new Vector3[wirePreview.positionCount];
            wirePreview.GetPositions(wirePositions);

            CmdConnectWires(playerStats.SelectedOutput, playerStats.energyInputLookingAt, playerStats.SelectedOutput.id, wirePositions, normals.ToArray());
        }

        [Command]
        private void CmdConnectWires(EnergyOutput connectedEnergyInputNetworkIdentity, EnergyInput energyInputLookingAtNetworkIdentity, int outputId, Vector3[] wirePositions, Vector3[] normals)
        {
            print("connecting " + connectedEnergyInputNetworkIdentity.name + " to " + energyInputLookingAtNetworkIdentity.name);
            var selectedOutput = connectedEnergyInputNetworkIdentity.GetComponentsInChildren<EnergyOutput>().First(x => x.id == outputId);
            var energyInputLookingAt = energyInputLookingAtNetworkIdentity.GetComponentInChildren<EnergyInput>();
            selectedOutput.connectedEnergyInput = energyInputLookingAt;

            selectedOutput.wirePositions.Clear();
            selectedOutput.wireNormals.Clear();

            selectedOutput.wirePositions.AddRange(wirePositions);
            selectedOutput.wireNormals.AddRange(normals);

            wireManager.ReCreateWires();
            electricityManager.TransferEnergy();

            RpcConnectWires(connectedEnergyInputNetworkIdentity, energyInputLookingAtNetworkIdentity, outputId);
        }

        private void RpcConnectWires(EnergyOutput connectedEnergyInputGO, EnergyInput energyInputLookingAtGO, int outputId)
        {
            print("connecting " + connectedEnergyInputGO.transform.name + " to " + energyInputLookingAtGO.transform.name);
            EnergyOutput selectedOutput = connectedEnergyInputGO.GetComponentsInChildren<EnergyOutput>().First(x => x.id == outputId);
            var energyInputLookingAt = energyInputLookingAtGO.GetComponentInChildren<EnergyInput>();
            selectedOutput.connectedEnergyInput = energyInputLookingAt;

            wireManager.ReCreateWires();
            electricityManager.TransferEnergy();
        }
    }
}