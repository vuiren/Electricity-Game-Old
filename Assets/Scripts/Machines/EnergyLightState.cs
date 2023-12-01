using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    public class EnergyLightState : NetworkBehaviour
    {
        [SyncVar]
        private bool lightTurnedOn;

        public bool LightTurnedOn { get => lightTurnedOn; set => lightTurnedOn = value; }
    }
}