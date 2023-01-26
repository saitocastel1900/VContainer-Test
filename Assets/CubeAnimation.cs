using DG.Tweening;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
   [SerializeField] private Transform _cubeTransform;
   
   [SerializeField] private Ease _ease;

   [SerializeField] private float _magnitude;
   
   private Sequence _sequence;

   private void Move(Vector3 direction,Vector3 rotate)
   {
      if (_sequence.IsActive()) return;

      _sequence = DOTween.Sequence()
         .Join(_cubeTransform.DORotate(rotate,1f,RotateMode.FastBeyond360).SetRelative())
         .Join(_cubeTransform.DOMove(direction*_magnitude,1f).SetRelative())
         .SetEase(_ease).SetLink(this.gameObject);
   }

   public void AheadMove()
   {
      Move(Vector3.forward,new Vector3(360,0,0));
   }
   public void LeftMove()
   {
      Move(Vector3.left,new Vector3(0,0,360));
   }

   public void RightMove()
   {
      Move(Vector3.right,new Vector3(0,0,-360));
   }

   public void BackMove()
   {
      Move(Vector3.back,new Vector3(-360,0,0));
   }
   
   public void Jump()
   {
      if (_sequence.IsActive()) return;

      _sequence = DOTween.Sequence()
         .Join(_cubeTransform.DOJump(new Vector3(0, 0, 0), 3f, 1, 1.0f).SetRelative())
         .Join(_cubeTransform.DOPunchRotation(new Vector3(360f, 360f, 360f), 1.0f,5).SetRelative())
         .SetEase(_ease).SetLink(this.gameObject);
   }
}
