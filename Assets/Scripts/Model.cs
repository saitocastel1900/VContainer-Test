using UniRx;

public class Model : IModel
{
   public IReactiveProperty<int> CountProp=>_countProp;
   private readonly IntReactiveProperty _countProp;

   public Model()
   {
      _countProp=new IntReactiveProperty(0);
   }

   public void AddCount()
   {
      _countProp.Value++;
   }
}
