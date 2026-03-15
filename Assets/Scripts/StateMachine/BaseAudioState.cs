using UnityEngine;

public abstract class BaseAudioState : MonoBehaviour
{
    protected AudioStateMachine AudioStateMachine;
    protected InputData InputData;
    protected ButtonSpriteChanger ButtonSpriteChanger;
    protected AudioSourceHandler AudioSourceHandler;

    public virtual void Initialize(AudioStateMachine audioStateMachine, InputData inputData, ButtonSpriteChanger buttonSpriteChanger, AudioSourceHandler audioSourceHandler)
    {
        AudioStateMachine = audioStateMachine;
        InputData = inputData;
        ButtonSpriteChanger = buttonSpriteChanger;
        AudioSourceHandler = audioSourceHandler;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
}
