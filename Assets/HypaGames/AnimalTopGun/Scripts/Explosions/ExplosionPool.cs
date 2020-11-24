using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class ExplosionPool : HelpersLib.Scripts.GenericObjectPool<ExplosionPooled>
    {
        public void PlayExplosion(Vector3 position)
        {
            ExplosionPooled pooled = base.Get();
            pooled.Init(this);
            pooled.transform.position = position;
            Debug.Log("Activate explosion");
            base.ActivateObject(pooled.gameObject);
        }
    }

}