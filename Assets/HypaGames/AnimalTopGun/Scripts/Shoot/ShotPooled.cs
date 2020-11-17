using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class ShotPooled : MonoBehaviour
    {
        private ShotPool _shotPool;

        [SerializeField]
        private float maxLifeTime = 5f;
        private float lifeTime;

        public void Init(ShotPool shotPool)
        {
            _shotPool = shotPool;
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
                _shotPool.ReturnToPool(this);
            }
        }
    }

}