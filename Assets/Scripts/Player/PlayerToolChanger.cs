using UnityEngine;

namespace Player
{
    public class PlayerToolChanger : PlayerComponent
    {
        public void TryToChangeTool()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (PlayerStats.currentPlayerTool == PlayerToolEnum.Wires)
                {
                    PlayerStats.currentPlayerTool = PlayerToolEnum.Dvoinik;
                }
                else
                {
                    PlayerStats.currentPlayerTool = PlayerToolEnum.Wires;
                }
            }
        }
    }
}