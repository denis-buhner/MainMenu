internal class IdleState : BaseAudioState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetIdleStyle();
        AudioSourceHandler.Mute();
    }
}