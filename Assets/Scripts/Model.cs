using UniRx;

public class Model
{
   public IReactiveProperty<int> ValueProp=>_valueProp;
   private readonly IntReactiveProperty _valueProp;

   public Model()
   {
      _valueProp=new IntReactiveProperty(0);
   }

   public void AddScore()
   {
      _valueProp.Value++;
   }

   private void SetValue(int value)
   {
      _valueProp.Value = value;
   }
}
