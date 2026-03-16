using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _groupName;

    public void SetVolume(float volume)
    {
        float dbVolume = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20;
        _audioMixer.SetFloat(_groupName, dbVolume);
    }

    public void Mute()
    {
        _audioSource.Pause();
    }

    public void Play()
    {
        _audioSource.Play();
    }
}

