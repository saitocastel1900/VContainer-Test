using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InputAsRx.Util{
    internal static class MouseButtonInputUtil{
        internal enum InputType{
            GetMouseButtonDown
        }

        private static readonly Dictionary<InputType, Func<int, bool>> inputTable = new Dictionary<InputType, Func<int, bool>>{
            {InputType.GetMouseButtonDown, Input.GetMouseButtonDown},
        };

        internal static IObservable<Unit> CreateSubject(InputType inputType, int button) =>
            Observable.EveryUpdate()
                .Where(_ => inputTable[inputType](button))
                .AsUnitObservable();
    }
}
