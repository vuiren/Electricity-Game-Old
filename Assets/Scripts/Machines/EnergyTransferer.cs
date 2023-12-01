using UnityEngine;

namespace Assets.Scripts
{
    public class EnergyTransferer : MonoBehaviour, IEnergyConsumer, IEnergyEmitter
    {
        [SerializeReference] private EnergyInput energyInput;
        [SerializeReference] private EnergyOutput energyOutput;

        public EnergyOutput EnergyOutput => energyOutput;

        public EnergyInput EnergyInput => energyInput;
    }
}