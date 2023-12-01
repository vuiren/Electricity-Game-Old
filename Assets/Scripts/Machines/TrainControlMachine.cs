using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    [RequireComponent(typeof(Machine))]
    public class TrainControlMachine : MonoBehaviour
    {
        [SerializeField] private InGameLever lever;
        private TerrainMover terrainMover;
        Machine machine;
        // Use this for initialization
        void Start()
        {
            machine = GetComponent<Machine>();
            terrainMover = FindObjectOfType<TerrainMover>();
        }

        // Update is called once per frame
        void Update()
        {
            terrainMover.enabled = machine.GotEnoughEnergyToWork && lever.activated;
        }
    }
}