using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSpriteChanger : MonoBehaviour
{
    [Header("TargetButton")]
    [SerializeField] private Button _button;

    [Header("Sprite1")]
    [SerializeField] private Sprite _normalImageEnable;
    [SerializeField] private Sprite _highlightedSpriteEnable;
    [SerializeField] private Sprite _pressedSpriteEnable;
    [SerializeField] private Sprite _selectedSpriteEnable;
    [SerializeField] private Sprite _disabledSpriteEnable;

    [Header("Sprite2")]
    [SerializeField] private Sprite _normalImageDisable;
    [SerializeField] private Sprite _highlightedSpriteDisable;
    [SerializeField] private Sprite _pressedSpriteDisable;
    [SerializeField] private Sprite _selectedSpriteDisable;
    [SerializeField] private Sprite _disabledSpriteDisable;

    [Header("Who can change button sprite")]
    [SerializeReference][SerializeField] private List<MonoBehaviour> _buttonChangers = new();

    private void OnEnable()
    {
        foreach(var gameObject in _buttonChangers)
        {
            if(gameObject is ICanChangeButton)
            {
                var buttonChanger = (ICanChangeButton)gameObject;
                buttonChanger.ButtonState += ChangeSprite;
            }
        }
    }

    private void OnDisable()
    {
        foreach (var gameObject in _buttonChangers)
        {
            if (gameObject is ICanChangeButton)
            {
                var buttonChanger = (ICanChangeButton)gameObject;
                buttonChanger.ButtonState -= ChangeSprite;
            }
        }
    }

    public void ChangeSprite(bool isActive)
    {
        if (isActive)
        {
            _button.image.sprite = _normalImageEnable;
            SpriteState spriteState = new SpriteState();
            spriteState.highlightedSprite = _highlightedSpriteEnable;
            spriteState.pressedSprite = _pressedSpriteEnable;
            spriteState.selectedSprite = _selectedSpriteEnable;
            spriteState.disabledSprite = _disabledSpriteEnable;
            _button.spriteState = spriteState;

            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            _button.image.sprite = _normalImageDisable;
            SpriteState spriteState = new SpriteState();
            spriteState.highlightedSprite = _highlightedSpriteDisable;
            spriteState.pressedSprite = _pressedSpriteDisable;
            spriteState.selectedSprite = _selectedSpriteDisable;
            spriteState.disabledSprite = _disabledSpriteDisable;
            _button.spriteState = spriteState;

            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
