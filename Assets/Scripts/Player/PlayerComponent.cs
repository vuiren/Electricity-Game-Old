using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public abstract class PlayerComponent : MonoBehaviour
    {
        protected PlayerSettings PlayerSettings;
        protected PlayerStats PlayerStats;
        public virtual void Construct(PlayerSettings playerSettings, PlayerStats playerStats)
        {
            PlayerStats = playerStats;
            PlayerSettings = playerSettings;
        }
    }
}