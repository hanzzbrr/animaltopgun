using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class Enemy : MonoBehaviour, IHealthContainer, ISpeedContainer
    {
        private float HP;
        private float moveSpeed;

        [SerializeField]
        SpawnedPooled _spawnedPooled;

        ExplosionPool _explosionPool;
        
        [SerializeField]
        private BaseMoveStrategy _baseMoveStrategy;

        private void Awake()
        {
            _explosionPool = FindObjectOfType<ExplosionPool>();
            _baseMoveStrategy = Instantiate(_baseMoveStrategy);
        }

        private void Update()
        {
            _baseMoveStrategy.PerformMove(transform, moveSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "PlayerShot")
            {
                OnPlayerShotCollision();
            }
        }

        public void OnPlayerShotCollision()
        {
            ShowHit();
            HP--;
            if(HP <= 0)
            {
                OnDeath();
            }
        }

        private void ShowHit()
        {
            // something like animation or material change
        }
        private void OnDeath()
        {
            //_explosionPool.PlayExplosion(transform.position);
            _spawnedPooled.EndLife();
        }

        public void SetHP(float value)
        {
            HP = value;
        }

        public void SetSpeed(float value)
        {
            moveSpeed = value;
        }
    }

    public interface IHealthContainer
    {
        void SetHP(float value);
    }
    public interface ISpeedContainer
    {
        void SetSpeed(float value);
    }
}
