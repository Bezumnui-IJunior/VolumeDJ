using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private const float MinimumVolume = -80f;

    [SerializeField] public Mixer _mixer;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnValueChanged);
        _mixer.SetVolume(NormalizeSound(_slider.value));
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(float volume)
    {
        if (volume == 0)
            _mixer.SetVolume(MinimumVolume);
        else
            _mixer.SetVolume(NormalizeSound(volume));
    }

    private float NormalizeSound(float volume)
    {
        const float Factor = 20;
        
        return Mathf.Log10(volume) * Factor;
    }
}