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
        _view.Initialize();
        Bind();
        SetEvent();
    }

    private void Bind()
    {
        _model.ValueProp
            .Subscribe(_view.SetCount)
            .AddTo(_compositeDisposable);
    }

    private void SetEvent()
    {
        _view.OnCallback += () => _model.AddScore();
        
        _view.InputJump()
            .Subscribe(_=>_view.Jump())
            .AddTo(_compositeDisposable);
    }
    
    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}