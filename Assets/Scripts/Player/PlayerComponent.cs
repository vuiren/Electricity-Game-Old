using UnityEngine;

namespace Player
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