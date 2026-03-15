using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ButtonSpriteChanger), typeof(InputData))]
public class AudioStateMachine : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InputData _inputData;
    [SerializeField] private ButtonSpriteChanger _buttonSpriteChanger;

    private Dictionary<Type, BaseAudioState> _states;
    private BaseAudioState _currentState;

    private PlayState _playState;
    private PauseState _pauseState;
    private IdleState _idleState;

    private float _previousVolume;

    private void Awake()
    {
        _playState = gameObject.AddComponent<PlayState>();
        _pauseState = gameObject.AddComponent<PauseState>();
        _idleState = gameObject.AddComponent<IdleState>();

        _states = GetComponents<BaseAudioState>().ToDictionary(state => state.GetType());

        foreach (var state in _states.Values)
        {
            state.Initialize(this, _inputData, _buttonSpriteChanger);
        }
    }

    private void Start()
    {
        ChangeState<IdleState>();
    }

    private void OnEnable()
    {
        _inputData.CustomButton.OnToggleChanged += HandleButtonToggle;
        _inputData.CustomSlider.Slider.onValueChanged.AddListener(HandleSliderToggle);
    }

    private void OnDisable()
    {
        _inputData.CustomButton.OnToggleChanged -= HandleButtonToggle;
        _inputData.CustomSlider.Slider.onValueChanged.RemoveListener(HandleSliderToggle);
    }

    private void HandleButtonToggle()
    {
        if (_currentState is PauseState || _currentState is IdleState)
        {
            ChangeState<PlayState>();
        }
        else
        {
            ChangeState<PauseState>();
        }
    }

    private void HandleSliderToggle(float value)
    {
        if (value > 0 && ( _currentState is PauseState || _currentState is IdleState))
        {
            ChangeState<PlayState>();
        }
        else if (value <= 0 && _currentState is PlayState)
        {
            ChangeState<PauseState>();
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
