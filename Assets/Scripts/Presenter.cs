using System;
using UniRx;
using VContainer;
using VContainer.Unity;

public class Presenter : IStartable, IDisposable
{
    private readonly View _view;
    private readonly IModel _model;
    
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    [Inject]
    public Presenter(View view, IModel model)
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
        _model.CountProp
            .Subscribe(_view.SetCount)
            .AddTo(_compositeDisposable);
    }

    private void SetEvent()
    {
        _view.OnAnimationCallback += () => _model.AddCount();
        
        _view.InputJump()
            .Subscribe(_=>_view.Jump())
            .AddTo(_compositeDisposable);
    }
    
    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}