using UniRx;

public class Model
{
   public IReactiveProperty<string> TextProp=>_textProp;
   private readonly StringReactiveProperty _textProp;

   public Model()
   {
      _textProp = new StringReactiveProperty("Idle");
   }

   public void Ahead()
   {
      SetText("Ahead");
   }

   public void Left()
   {
      SetText("Left");
   }

   public void Right()
   {
      SetText("Right");
   }

   public void Back()
   {
      SetText("Back");
   }
   
   public void Jump()
   {
      SetText("Jump");
   }

   public void Idle()
   {
      SetText("Idle");
   }

   private void SetText(string value)
   {
      _textProp.Value = value;
   }
}
