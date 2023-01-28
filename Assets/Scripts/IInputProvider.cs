using System;
using UniRx;

public interface IInputProvider
{ 
    public IObservable<Unit> InputJump();
}