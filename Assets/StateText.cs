using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class StateText : MonoBehaviour
{
    [SerializeField] private Text _text;
    
    public IReactiveProperty<string> TextProp=>_textProp; 
    private StringReactiveProperty _textProp;

    public void Initialize()
    {
        _textProp = new StringReactiveProperty("Idle");
    }

    public void Idle()
    {
        SetTextProp("Idle");
    }

    public void Jump()
    {
        SetTextProp("Jump");
    }

    public void Ahead()
    {
        SetTextProp("Ahead");
    }

    public void Left()
    {
        SetTextProp("Left");
    }

    public void Right()
    {
        SetTextProp("Right");
    }

    public void Back()
    {
        SetTextProp("Back");
    }

    public void SetText(string state)
    {
        _text.text = state;
    }

    private void SetTextProp(string text)
    {
        _textProp.Value = text;
    }
}