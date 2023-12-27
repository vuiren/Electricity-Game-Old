using UnityEngine;

namespace Assets.Scripts.Machines
{
    [RequireComponent(typeof(Machine), typeof(EnergyLightState))]
    public class EnergyLight : MonoBehaviour
    {
        Machine machine;
        EnergyLightState energyLightState;
        [SerializeField] private Light[] lights;

        // Use this for initialization
        void Start()
        {
            machine = GetComponent<Machine>();
            energyLightState = GetComponent<EnergyLightState>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            foreach (var light in lights)
            {
                light.enabled = energyLightState.LightTurnedOn && machine.GotEnoughEnergyToWork;
            }
        }

        public void ToggleLight()
        {
            energyLightState.LightTurnedOn = !energyLightState.LightTurnedOn;
        }
    }
}