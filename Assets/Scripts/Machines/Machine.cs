using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Machine : MonoBehaviour
    {
        const float error = 0.04f;
        [SerializeField] private float energyConsumption;
        [SerializeField] private float energyStored;
        public float energyLeftInSystem;

        public UnityEvent<float> OnEnergyStoredChanged;
        public float EnergyConsumption { get => energyConsumption; set => energyConsumption = value; }
        public float EnergyStored
        {
            get => energyStored; set
            {
                energyStored = value;
                OnEnergyStoredChanged?.Invoke(value);
            }
        }

        public bool GotEnoughEnergyToWork => Mathf.Abs(energyStored - energyConsumption) < error;
    }
}