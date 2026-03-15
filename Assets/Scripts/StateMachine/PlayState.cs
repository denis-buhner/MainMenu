public class PlayState : BaseAudioState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetPlayStyle();
        InputData.CustomSlider.RestoreVolume();
        AudioSourceHandler.Play();
    }
}
