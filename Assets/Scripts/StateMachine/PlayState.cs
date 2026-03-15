using UnityEngine;

public class PlayState : BaseAudioState
{
    public override void Enter()
    {
        ButtonSpriteChanger.SetPlayStyle();
        InputData.CustomSlider.RestoreVolume();
    }
}
