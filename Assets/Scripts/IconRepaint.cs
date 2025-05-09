using UnityEngine;
using UnityEngine.UI;

public class IconRepaint
{
    private readonly Image _icon;
    private readonly Color _initialColor;

    public IconRepaint(Image icon)
    {
        _icon = icon;
        _initialColor = icon.color;
    }

    public void Paint(Color color)
    {
        _icon.color = color;
    }

    public void RestoreColor()
    {
        _icon.color = _initialColor;
    }
}