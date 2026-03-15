using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewButtonConfig", menuName = "UI/Button Config")]
public class ButtonVisualConfig : ScriptableObject
{
    [SerializeField] private Sprite _normal;
    [SerializeField] private Sprite _highlighted;
    [SerializeField] private Sprite _pressed;
    [SerializeField] private Sprite _selected;
    [SerializeField] private Sprite _disabled;

    public void ApplyTo(Button button)
    {
        button.image.sprite = _normal;

        SpriteState spriteState = new SpriteState
        {
            highlightedSprite = _highlighted,
            pressedSprite = _pressed,
            selectedSprite = _selected,
            disabledSprite = _disabled,
        };
        
        button.spriteState = spriteState;
    }
}
