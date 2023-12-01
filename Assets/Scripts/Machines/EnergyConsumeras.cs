using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnergyConsumeras : MonoBehaviour, IEnergyConsumer
    {
        public EnergyInput energyInput;
        public float energyConsumption;

        public EnergyInput EnergyInput => energyInput;
    }
}