using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Generator : MonoBehaviour, IEnergyEmitter
    {
        [SerializeField] private EnergyOutput generatorOutput;
        [SerializeField] public float energyGeneration;
        public float generatedEnergy;
        public EnergyOutput EnergyOutput => generatorOutput;

        private void Start()
        {
            generatedEnergy = energyGeneration;
        }
    }
}