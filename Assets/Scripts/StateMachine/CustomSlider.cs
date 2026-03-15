using UnityEngine;
using UnityEngine.UI;
public class CustomSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _lastVolume = 0.5f;

    public Slider Slider => _slider;
    public bool IsInPlay => _slider.value > 0f;

    public void SaveCurrentVolume()
    {
         _lastVolume = _slider.value;
    }

    public void RestoreVolume()
    {
        if (_slider.value > 0)
            return;

        _slider.value = _lastVolume;
    }

    public void Mute()
    {
        if (_slider.value <= 0)
            return;

        _slider.value = 0;
    }
}