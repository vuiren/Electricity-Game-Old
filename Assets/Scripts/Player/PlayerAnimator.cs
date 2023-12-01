using Assets.Scripts.Player;

public class PlayerAnimator : PlayerComponent
{
    public void Animate()
    {
        PlayerSettings.playerCharacterAnimator.SetBool("moving", PlayerStats.moving);
        PlayerSettings.playerCharacterAnimator.SetBool("pointing", PlayerStats.creatingWire);
    }
}
