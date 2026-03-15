using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomButton), typeof(CustomSlider))]
public class InputData : MonoBehaviour
{
    [SerializeField] private CustomSlider _customSlider;
    [SerializeField] private CustomButton _customButton;

    public CustomButton CustomButton => _customButton;
    public CustomSlider CustomSlider => _customSlider;
}