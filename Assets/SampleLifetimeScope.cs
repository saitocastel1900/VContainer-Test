using UnityEngine;
using VContainer;
using VContainer.Unity;

public class SampleLifetimeScope : LifetimeScope
{
    [SerializeField] private CubeAnimation _animation;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IInputProvider,KeyInputProvider>(Lifetime.Singleton);

        builder.RegisterComponent(_animation);
        
        builder.RegisterEntryPoint<CubeEvent>();
    }
}
