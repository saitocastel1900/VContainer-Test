using DG.Tweening;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
   [SerializeField] private Transform _cubeTransform;
   [SerializeField] private Ease _ease;

   private Sequence _sequence = null;

   private void Move()
   {
      if (_sequence.IsActive()) return;

      _sequence = DOTween.Sequence()
         .Join(_cubeTransform.DOLocalJump(new Vector3(0, 0.5f, 0), 3f, 1, 1f))
         .Join(_cubeTransform.DOLocalRotate(new Vector3(360f, 360f, 360f), 0.6f).SetRelative())
         .SetEase(_ease);
   }

   public void AheadMove()
   {
      Move();
   }
   
   public void BackMove()
   {
      Move();
   }
   
   public void RightMove()
   {
      Move();
   }
   
   public void LeftMove()
   {
      Move();
   }

   public void Jump()
   {
      if (_sequence.IsActive()) return;

      _sequence = DOTween.Sequence()
         .Join(_cubeTransform.DOLocalJump(new Vector3(0, 0.5f, 0), 3f, 1, 1f))
         .Join(_cubeTransform.DOLocalRotate(new Vector3(360f, 360f, 360f), 0.6f).SetRelative())
         .SetEase(_ease);
   }
}
