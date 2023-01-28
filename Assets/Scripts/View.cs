using System;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;
using UnityEngine;
using VContainer;

public class View : MonoBehaviour
{
    [SerializeField] private Transform _cubeTransform;
    private Sequence _sequence;

    [SerializeField] private Text _text;

    [Inject] 
    IInputProvider _input;
    
    public event Action OnCallBack;

    public Subject<Unit> _Subject;

    public void SetText(string state)
    {
        _text.text = state;
    }

    public IObservable<Unit> InputJump()
    {
        return _input.InputJump();
    }

    public void Jump()
    {
        if (_sequence.IsActive()) return;

        _sequence = DOTween.Sequence()
            .Join(_cubeTransform.DOJump(new Vector3(0, 0, 0), 3f, 1, 1.0f).SetRelative())
            .Join(_cubeTransform.DOPunchRotation(new Vector3(360f, 360f, 360f), 1.0f,5).SetRelative())
            .SetEase(Ease.OutCubic).SetLink(this.gameObject).OnComplete(()=>OnCallBack?.Invoke());
    }
}

