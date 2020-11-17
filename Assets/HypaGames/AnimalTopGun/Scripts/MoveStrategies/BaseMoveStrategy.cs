using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public abstract class BaseMoveStrategy : ScriptableObject
    {
        public abstract void PerformMove(Transform originTransform, float speed);
    }
}
