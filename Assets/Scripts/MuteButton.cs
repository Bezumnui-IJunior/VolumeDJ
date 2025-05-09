using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Mixer _mixer;
    [SerializeField] private Color _mutedColor;

    private Button _button;
    private IconRepaint _iconRepaint;
    private bool _isMuted;

    private void Awake()
    {
        _iconRepaint = new IconRepaint(_image);
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        if (_isMuted)
        {
            _iconRepaint.RestoreColor();
            _mixer.UnMute();
        }
        else
        {
            _iconRepaint.Paint(_mutedColor);
            _mixer.Mute();
        }

        _isMuted = !_isMuted;
    }
}