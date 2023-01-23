using VContainer;
using VContainer.Unity;

public class CubeEvent :  ITickable
{
   readonly CubeAnimation _cubeAnimation;
   readonly IInputProvider _input;
   
   [Inject]
   public CubeEvent(CubeAnimation cubeAnimation,IInputProvider input)
   {
      _cubeAnimation = cubeAnimation;
      _input = input;
   }

   public void Tick()
   {
      if (_input.InputAhead())
      {
         _cubeAnimation.AheadMove();
      }
      else if (_input.InputLeft())
      {
         _cubeAnimation.LeftMove();
      }
      else if (_input.InputRight())
      {
         _cubeAnimation.RightMove();
      }
      else if (_input.InputBack())
      {
         _cubeAnimation.BackMove();
      }
      else if (_input.InputJump())
      {
         _cubeAnimation.Jump();
      }
   }
}
