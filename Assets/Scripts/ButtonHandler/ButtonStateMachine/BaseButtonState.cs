using UnityEngine;

public abstract class BaseButtonState : MonoBehaviour
{
    protected ButtonStateMachine StateMachine;
    protected ButtonSpriteChanger ButtonSpriteChanger;

    public virtual void Initialize(ButtonStateMachine stateMachine, ButtonSpriteChanger buttonSpriteChanger)
    {
        StateMachine = stateMachine;
        ButtonSpriteChanger = buttonSpriteChanger;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
}
