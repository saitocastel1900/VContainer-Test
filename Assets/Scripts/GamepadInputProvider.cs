using System;
using InputAsRx;
using UniRx;

public class GamepadInputProvider : IInputProvider
{
    public IObservable<Unit> InputJump()
    {
        return InputAsObservable.GetMouseButtonDown(0);
    }
}