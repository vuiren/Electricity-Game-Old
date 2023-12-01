using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    [RequireComponent(typeof(Machine), typeof(EnergyLightState))]
    public class EnergyLight : NetworkBehaviour
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
            if (isClientOnly)
            {
                CmdToggleLight();
            }
            else
                energyLightState.LightTurnedOn = !energyLightState.LightTurnedOn;
        }

        [Command]
        private void CmdToggleLight()
        {
            energyLightState.LightTurnedOn = !energyLightState.LightTurnedOn;
        }
    }
}