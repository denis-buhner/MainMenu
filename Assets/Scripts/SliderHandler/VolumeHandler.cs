using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(AudioSourceHandler), typeof(CustomSlider))]
public class VolumeHandler : MonoBehaviour
{
    [SerializeField] private AudioSourceHandler _audioSourceHandler;
    [SerializeField] private CustomSlider _customSlider;
    
    private float _startVolume = .5f;

    public event Action<float> SliderChanged;
    public AudioSourceHandler AudioSourceHandler => _audioSourceHandler;
    public CustomSlider CustomSlider => _customSlider;

    private void OnEnable()
    {
        _customSlider.Slider.onValueChanged.AddListener(HandleSliderChange);
        _audioSourceHandler.SetVolume(_startVolume);
        _customSlider.Slider.value = _startVolume;
    }

    private void HandleSliderChange(float value)
    {
        _audioSourceHandler.SetVolume(value);
        SliderChanged?.Invoke(value);
    }
}
