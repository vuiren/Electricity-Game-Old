using Assets.Scripts;
using UnityEngine;

namespace Player
{
    public class PlayerLookAtController : PlayerComponent
    {
        // Update is called once per frame
        public void UpdateLook()
        {
            if (!PlayerSettings.playerCamera) return;
            PlayerStats.energyInputLookingAt = null;
            PlayerStats.energyOutputLookingAt = null;
            PlayerStats.interactableLookingAt = null;

            var ray = PlayerSettings.playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out var hit))
            {
                PlayerStats.latestLookAtHit = hit;
                if (hit.transform.TryGetComponent(out EnergyOutput energyOutput))
                {
                    PlayerStats.energyOutputLookingAt = energyOutput;
                }
                if (hit.transform.TryGetComponent(out EnergyInput energyInput))
                {
                    PlayerStats.energyInputLookingAt = energyInput;
                }
                if(hit.transform.TryGetComponent(out IInteractable interactable))
                {
                    PlayerStats.interactableLookingAt = interactable;
                }
            }
        }
    }
}