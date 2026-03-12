using System;
using UnityEngine;

[Serializable]
public class CustomButton : MonoBehaviour, ICanChangeButton
{
    private bool _isActive;

    public event Action<bool> ButtonState;

    public void ChangeButtonState()
    {
        if(_isActive)
        {
            ButtonState?.Invoke(false);
            _isActive = false;
        }
        else
        {
            ButtonState?.Invoke(true);
            _isActive = true;
        }
    }
}
