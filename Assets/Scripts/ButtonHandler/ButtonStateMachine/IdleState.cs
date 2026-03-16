internal class IdleState : BaseButtonState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetIdleStyle();
    }
}