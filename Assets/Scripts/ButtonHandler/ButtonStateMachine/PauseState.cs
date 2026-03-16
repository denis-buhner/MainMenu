public class PauseState : BaseButtonState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetPauseStyle();
    }
}
