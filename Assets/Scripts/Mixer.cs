using UnityEngine;
using UnityEngine.Audio;

public class Mixer : MonoBehaviour, IMixer
{
    private const float MinimumVolume = -80f;

    [SerializeField] public AudioMixer _audioMixer;
    [SerializeField] public string _volumeName;

    private float _volume;
    private bool _isMute;

    private void Awake()
    {
        _audioMixer.GetFloat(_volumeName, out _volume);
    }

    public void SetVolume(float volume)
    {
        _volume = volume;

        if (_isMute == false)
            SetDirectVolume(_volume);
    }

    public void Mute()
    {
        _isMute = true;
        SetDirectVolume(MinimumVolume);
    }

    public void UnMute()
    {
        _isMute = false;

        SetDirectVolume(_volume);
    }

    private void SetDirectVolume(float volume)
    {
        _audioMixer.SetFloat(_volumeName, volume);
    }
}