using UnityEngine;
using VContainer;
using VContainer.Unity;

public class SampleLifetimeScope : LifetimeScope
{
    [SerializeField] private CubeAnimation _animation;
    [SerializeField] private StateText _text;

    protected override void Configure(IContainerBuilder builder)
    {
#if UNITY_EDITOR
        builder.Register<IInputProvider, GamepadInputProvider>(Lifetime.Transient);
#elif UNITY_WEBGL
        builder.Register<IInputProvider,KeyInputProvider>(Lifetime.Transient);
#endif
        builder.RegisterComponent(_animation);

        builder.RegisterComponent(_text);

        builder.RegisterEntryPoint<CubeEvent>();
    }
}