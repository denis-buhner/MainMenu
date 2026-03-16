using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ButtonSpriteChanger), typeof(CustomButton))]
public class ButtonStateMachine : MonoBehaviour
{
    [SerializeField] private ButtonSpriteChanger _buttonSpriteChanger;
    [SerializeField] private CustomButton _customButton;

    private PlayState _playState;
    private PauseState _pauseState;
    private IdleState _idleState;
    private MuteState _muteState;

    private Dictionary<Type, BaseButtonState> _states;
    private BaseButtonState _currentState;

    public event Action<BaseButtonState> CurrentState;

    public void Initialize()
    {
        _playState = gameObject.AddComponent<PlayState>();
        _pauseState = gameObject.AddComponent<PauseState>();
        _idleState = gameObject.AddComponent<IdleState>();
        _muteState = gameObject.AddComponent<MuteState>();

        _states = GetComponents<BaseButtonState>().ToDictionary(state => state.GetType());

        foreach (var state in _states.Values)
        {
            state.Initialize(this, _buttonSpriteChanger);
        }

        ChangeState<IdleState>();
    }

    private void OnEnable()
    {
        _customButton.OnToggleChanged += HandleButtonClick;
    }
    private void OnDisable()
    {
        _customButton.OnToggleChanged -= HandleButtonClick;
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

    public void NotifyVolumeChanged(float value)
    {
        if (value > 0 && ( _currentState is MuteState))
        {
            ChangeState<IdleState>();
        }
        else if (value <= 0 && !(_currentState is MuteState))
        {
            ChangeState<MuteState>();
        }
    }

    private void ChangeState<TState>() where TState : BaseButtonState
    {
        if (_states.TryGetValue(typeof(TState), out var newState))
        {
            if (_currentState == newState)
                return;

            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();

            CurrentState?.Invoke(_currentState);
        }
    }
}
