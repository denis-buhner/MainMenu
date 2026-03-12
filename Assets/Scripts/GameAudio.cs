using System;
using UnityEngine;
using UnityEngine.Audio;

public class GameAudio : MonoBehaviour, ICanChangeButton
{
    public event Action<bool> ButtonState;

    [SerializeField] private AudioSource _currentSource = null;
    [SerializeField] private AudioMixer _currentMixer;
    [SerializeField] private string _currentGroupName;

    private bool _isPlay;

    public void ChangeAudioState()
    {
        if (_isPlay)
        {
            _currentSource.Pause();
            Debug.Log("пауза");
            _isPlay = false;
            ButtonState?.Invoke(false);
        }
        else
        {
            _currentSource.Play();
            Debug.Log("снял с паузы");
            _isPlay = true;
            ButtonState?.Invoke(true);
        }
    }

    public void SetVolume(float volume)
    {
        if(volume > 0)
        {
            if(!_isPlay)
            {
                ChangeAudioState();
                ButtonState?.Invoke(true);
            }
        }
        else
        {
            if (_isPlay)
            {
                ChangeAudioState();
                ButtonState?.Invoke(false);
            }
        }

        float dbVolume = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20;
        _currentMixer.SetFloat(_currentGroupName, dbVolume);

        Debug.Log($"Текущее значение скроллбара: {volume}, в децибелах: {dbVolume}");
    }
}
