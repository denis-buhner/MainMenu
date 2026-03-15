using UnityEngine;

[RequireComponent(typeof(ButtonSpriteChanger), typeof(InputData), typeof(AudioSourceHandler))]
[RequireComponent(typeof(AudioStateMachine))]
public class AudioFacade : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InputData _inputData;
    [SerializeField] private ButtonSpriteChanger _buttonSpriteChanger;
    [SerializeField] private AudioSourceHandler _audioSourceHandler;
    [SerializeField] private AudioStateMachine _audioStateMachine;

    private void Start()
    {
        if(_audioStateMachine != null)
            _audioStateMachine.Initialize(_inputData, _buttonSpriteChanger, _audioSourceHandler);
    }

    private void OnEnable()
    {
        if(_inputData.CustomButton != null)
        {
            _inputData.CustomButton.OnToggleChanged += HandleButtonToggle;
        }

        if(_inputData.CustomSlider != null)
        {
            _inputData.CustomSlider.Slider.onValueChanged.AddListener(HandleSliderToggle);
        }
    }

    private void OnDisable()
    {
        if (_inputData.CustomButton != null)
        {
            _inputData.CustomButton.OnToggleChanged -= HandleButtonToggle;
        }

        if (_inputData.CustomSlider != null)
        {
            _inputData.CustomSlider.Slider.onValueChanged.RemoveListener(HandleSliderToggle);
        }
    }

    private void HandleButtonToggle()
    {
        _audioStateMachine.HandleButtonClick();
    }

    private void HandleSliderToggle(float value)
    {
        _audioSourceHandler.SetVolume(value);

        if(_audioStateMachine != null)
        {
            _audioStateMachine.HandleVolumeChange(value);
        }
    }
}
