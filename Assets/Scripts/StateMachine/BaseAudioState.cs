using UnityEngine;

public abstract class BaseAudioState : MonoBehaviour
{
    protected AudioStateMachine AudioStateMachine;
    protected InputData InputData;
    protected ButtonSpriteChanger ButtonSpriteChanger;

    public virtual void Initialize(AudioStateMachine audioStateMachine, InputData inputData, ButtonSpriteChanger buttonSpriteChanger)
    {
        AudioStateMachine = audioStateMachine;
        InputData = inputData;
        ButtonSpriteChanger = buttonSpriteChanger;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
}
