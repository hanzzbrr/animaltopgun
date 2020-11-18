using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class TriggerStrategy : ScriptableObject
    {
        public virtual bool CheckCollision(Collider other)
        {
            return true;
        }
    }

    public class BulletStrategy : TriggerStrategy
    {
        public override bool CheckCollision(Collider other)
        {
            return other.tag == "Enemy";
        }
    }
}
