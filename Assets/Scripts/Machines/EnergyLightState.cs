using UnityEngine;

namespace Assets.Scripts.Machines
{
    public class EnergyLightState : MonoBehaviour
    {
        private bool lightTurnedOn;

        public bool LightTurnedOn { get => lightTurnedOn; set => lightTurnedOn = value; }
    }
}