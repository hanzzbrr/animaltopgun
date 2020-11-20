using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    [CreateAssetMenu(menuName = "Hypa Games/Move Linear Strategy")]
    public class MoveLinearStrategy : BaseMoveStrategy
    {
        public override void PerformMove(Transform originTransform, float speed)
        {
            originTransform.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
