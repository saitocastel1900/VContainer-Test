using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MvpLifetimeScope : LifetimeScope
{
    [SerializeField] private View _view;

    protected override void Configure(IContainerBuilder builder)
    {
#if UNITY_EDITOR
        builder.Register<IInputProvider, GamepadInputProvider>(Lifetime.Transient);
#elif UNITY_WEBGL
        builder.Register<IInputProvider,KeyInputProvider>(Lifetime.Transient);
#endif
        builder.Register<IModel,Model>(Lifetime.Transient);

        builder.RegisterComponent(_view);

        builder.RegisterEntryPoint<Presenter>();
    }
}
