using UnityEngine;

public class PauseState : BaseAudioState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetPauseStyle();
        InputData.CustomSlider.SaveCurrentVolume();
        InputData.CustomSlider.Mute();
    }
}
