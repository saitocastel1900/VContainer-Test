using System;
using InputAsRx;
using UniRx;
using UnityEngine;

public class KeyInputProvider : IInputProvider
{
    public IObservable<Unit> InputJump()
    {
        return InputAsObservable.GetKeyDown(KeyCode.Space);
    }
}
