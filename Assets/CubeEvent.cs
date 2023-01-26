using UniRx;
using VContainer;
using VContainer.Unity;

public class CubeEvent : IStartable, ITickable
{
    readonly CubeAnimation _cubeAnimation;
    readonly IInputProvider _input;
    private readonly StateText _text;

    [Inject]
    public CubeEvent(CubeAnimation cubeAnimation, IInputProvider input, StateText text)
    {
        _cubeAnimation = cubeAnimation;
        _input = input;
        _text = text;
    }

    public void Start()
    {
        _text.Initialize();
        
        _text
            .TextProp
            .DistinctUntilChanged()
            .Subscribe(_text.SetText);
    }

    public void Tick()
    {
        if (_input.InputAhead())
        {
            _text.Ahead();
            _cubeAnimation.AheadMove();
        }
        else if (_input.InputLeft())
        {
            _text.Left();
            _cubeAnimation.LeftMove();
        }
        else if (_input.InputRight())
        {
            _text.Right();
            _cubeAnimation.RightMove();
        }
        else if (_input.InputBack())
        {
            _text.Back();
            _cubeAnimation.BackMove();
        }
        else if (_input.InputJump())
        {
            _text.Jump();
            _cubeAnimation.Jump();
        }
        else
        {
            _text.Idle();
        }
    }
}