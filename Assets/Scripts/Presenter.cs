using System;
using UniRx;
using VContainer;
using VContainer.Unity;

public class Presenter : IStartable, IDisposable
{
    private readonly View _view;
    private readonly Model _model;
    
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    [Inject]
    public Presenter(View view, Model model)
    {
        _view = view;
        _model = model;
    }

    public void Start()
    {
        Bind();
        SetEvent();
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
        
        _view.InputJump()
            .Subscribe(_=>_view.Jump())
            .AddTo(_compositeDisposable);
    }
    
    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}