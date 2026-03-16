internal class MuteState : BaseButtonState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetMuteStyle();
    }
}