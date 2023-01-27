using System;
using UniRx;
using VContainer;
using VContainer.Unity;

public class Presenter : IStartable, IDisposable, ITickable
{
    private readonly View _view;
    private readonly Model _model;

    readonly IInputProvider _input;
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    [Inject]
    public Presenter(View view, Model model, IInputProvider input)
    {
        _view = view;
        _model = model;
        _input = input;
    }

    public void Start()
    {
        Bind();
        SetEvent();
    }

    public void Tick()
    {
        if (_input.InputAhead())
        {
            _model.Ahead();
            _view.AheadMove();
        }
        else if (_input.InputLeft())
        {
            _model.Left();
            _view.LeftMove();
        }
        else if (_input.InputRight())
        {
            _model.Right();
            _view.RightMove();
        }
        else if (_input.InputBack())
        {
            _model.Back();
            _view.BackMove();
        }
        else if (_input.InputJump())
        {
            _model.Jump();
            _view.Jump();
        }
    }

    private void Bind()
    {
        _model.TextProp
            .DistinctUntilChanged()
            .Subscribe(_view.SetText)
            .AddTo(_compositeDisposable);
    }

    private void SetEvent()
    {
        _view.OnCallBack += () => _model.Idle();
    }


    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}