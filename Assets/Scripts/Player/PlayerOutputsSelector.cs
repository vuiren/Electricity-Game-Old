using UnityEngine;

namespace Assets.Scripts.Player
{
    internal class PlayerOutputsSelector : PlayerComponent
    {
        public void Select()
        {
            if (!Input.GetMouseButton(0))
            {
                return;
            }

            if (!PlayerStats.SelectedOutput && PlayerStats.energyOutputLookingAt)
            {
                PlayerStats.SelectedOutput = PlayerStats.energyOutputLookingAt; //selecting
                PlayerStats.creatingWire = true;
                PlayerStats.OnOutputSelection?.Invoke();
            }
        }
    }
}
