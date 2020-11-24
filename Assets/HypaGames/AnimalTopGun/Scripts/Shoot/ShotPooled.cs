using UnityEngine;

namespace HypaGames.AnimalTopGun
{

    // Properties:
    // have a life cycle dependent on pool
    public class ShotPooled : MonoBehaviour
    {
        [SerializeField]
        private BaseMoveStrategy _baseMoveStrategy;

        public ShotPool ShotPool;

        [SerializeField]
        private float maxLifeTime = 5f;
        private float lifeTime;
        public float BulletSpeed;

        public void Init(ShotPool shotPool)
        {
            ShotPool = shotPool;
        }

        private void OnEnable()
        {
            lifeTime = 0f;            
        }

        public void Update()
        {
            lifeTime += Time.deltaTime;
            if (lifeTime > maxLifeTime)
            {
                EndLife();
            }
            _baseMoveStrategy.PerformMove(transform, BulletSpeed);
        }

        public void EndLife()
        {
            ShotPool.ReturnToPool(this);
        }


    }

}