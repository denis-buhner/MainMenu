using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSpriteChanger : MonoBehaviour
{
    [SerializeField] private ButtonVisualConfig _idle;
    [SerializeField] private ButtonVisualConfig _playConfig;
    [SerializeField] private ButtonVisualConfig _pauseConfig;
    [SerializeField] private ButtonVisualConfig _muteConfig;
    [SerializeField] private Button _button;

    public void SetIdleStyle()
    {
        _idle.ApplyTo(_button);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void SetPlayStyle()
    {
        _playConfig.ApplyTo(_button);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void SetPauseStyle()
    {
        _pauseConfig.ApplyTo(_button);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void SetMuteStyle()
    {
        _muteConfig.ApplyTo(_button);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
