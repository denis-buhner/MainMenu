using UnityEngine;

[RequireComponent(typeof(ButtonStateMachine), typeof(VolumeHandler))]
public class AudioMediator : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private VolumeHandler _volumeHandler;
    [SerializeField] private ButtonStateMachine _buttonStateMachine;

    private void Start()
    {
        if(_buttonStateMachine != null)
            _buttonStateMachine.Initialize();
    }

    private void OnEnable()
    {
        if(_volumeHandler != null)
        {
            _volumeHandler.SliderChanged += HandleSliderToggle;
        }

        if (_buttonStateMachine != null)
        {
            _buttonStateMachine.CurrentState += SyncAudioWithState;
        }
    }

    private void OnDisable()
    {
        if (_volumeHandler != null)
        {
            _volumeHandler.SliderChanged -= HandleSliderToggle;
        }

        if (_buttonStateMachine != null)
        {
            _buttonStateMachine.CurrentState -= SyncAudioWithState;
        }
    }

    private void HandleSliderToggle(float value)
    {
        if(_buttonStateMachine != null)
        {
            _buttonStateMachine.NotifyVolumeChanged(value);
        }
    }

    private void SyncAudioWithState(BaseButtonState state)
    {
        if (state is PlayState)
        {
            _volumeHandler.CustomSlider.RestoreVolume();
            _volumeHandler.AudioSourceHandler.Play();
        }
        else if (state is PauseState || state is MuteState)
        {
            if (state is PauseState)
            {
                _volumeHandler.CustomSlider.SaveCurrentVolume();
            }

            _volumeHandler.AudioSourceHandler.Mute();
        }
    }
}
