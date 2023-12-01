using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    public class EnergyDoorState : NetworkBehaviour
    {
        [SyncVar]
        public bool opened;
    }
}