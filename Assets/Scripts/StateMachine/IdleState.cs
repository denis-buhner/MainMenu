internal class IdleState : BaseAudioState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetIdleStyle();
    }
}