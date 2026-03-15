using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioStateMachine : MonoBehaviour
{
    private InputData _inputData;
    private ButtonSpriteChanger _buttonSpriteChanger;
    private AudioSourceHandler _audioSourceHandler;

    private PlayState _playState;
    private PauseState _pauseState;
    private IdleState _idleState;
    private MuteState _muteState;

    private Dictionary<Type, BaseAudioState> _states;
    private BaseAudioState _currentState;

    public void Initialize(InputData inputData, ButtonSpriteChanger buttonSpriteChanger, AudioSourceHandler audioSourceHandler)
    {
        _inputData = inputData;
        _buttonSpriteChanger = buttonSpriteChanger;
        _audioSourceHandler = audioSourceHandler;

        _playState = gameObject.AddComponent<PlayState>();
        _pauseState = gameObject.AddComponent<PauseState>();
        _idleState = gameObject.AddComponent<IdleState>();
        _muteState = gameObject.AddComponent<MuteState>();

        _states = GetComponents<BaseAudioState>().ToDictionary(state => state.GetType());

        foreach (var state in _states.Values)
        {
            state.Initialize(this, _inputData, _buttonSpriteChanger, _audioSourceHandler);
        }

        ChangeState<IdleState>();
    }

    public  void HandleButtonClick()
    {
        if (_currentState is PlayState == false)
        {
            ChangeState<PlayState>();
        }
        else
        {
            ChangeState<PauseState>();
        }
    }

    public void HandleVolumeChange(float value)
    {
        _audioSourceHandler.SetVolume(value);

        if (value > 0 && ( _currentState is MuteState))
        {
            ChangeState<IdleState>();
        }
        else if (value <= 0 && !(_currentState is MuteState))
        {
            ChangeState<MuteState>();
        }
    }

    private void ChangeState<TState>() where TState : BaseAudioState
    {
        if (_states.TryGetValue(typeof(TState), out var newState))
        {
            if (_currentState == newState)
                return;

            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}
