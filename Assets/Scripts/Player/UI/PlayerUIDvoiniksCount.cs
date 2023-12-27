namespace Player.UI
{
    public class PlayerUIDvoiniksCount : PlayerComponent
    {
        DvoinikUI dvoinikUI;
        public override void Construct(PlayerSettings playerSettings, PlayerStats playerStats)
        {
            base.Construct(playerSettings, playerStats);
            dvoinikUI = FindObjectOfType<DvoinikUI>();
        }

        public void UpdateText()
        {
            dvoinikUI.dvoiniksCountText.text = PlayerStats.dvoiniksCount.ToString();
        }
    }
}
