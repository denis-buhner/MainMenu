internal class MuteState : BaseAudioState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetMuteStyle();
        InputData.CustomSlider.Mute();
        AudioSourceHandler.Mute();
    }
}