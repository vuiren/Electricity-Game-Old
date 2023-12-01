using Mirror;
using UnityEngine;

namespace Assets.Scripts.MiniGenerator
{
    public class MiniGeneratorState : NetworkBehaviour
    {
        [SyncVar]
        public bool moving;
    }
}