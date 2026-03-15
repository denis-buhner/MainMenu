public class PauseState : BaseAudioState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetPauseStyle();
        InputData.CustomSlider.SaveCurrentVolume();
        AudioSourceHandler.Mute();
    }
}
