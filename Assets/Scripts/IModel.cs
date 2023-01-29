using UniRx;

public interface IModel
{
    public IReactiveProperty<int> CountProp { get; }
    
    public void AddCount();
}
