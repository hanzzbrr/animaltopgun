using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class Enemy : MonoBehaviour
    {
        public int HP;

        [SerializeField]
        SpawnedPooled _spawnedPooled;

        ExplosionPool _explosionPool;

        private void Awake()
        {
            _explosionPool = FindObjectOfType<ExplosionPool>();
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
            if(HP < 0)
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
            _explosionPool.PlayExplosion(transform.position);
            _spawnedPooled.EndLife();
        }
    }
}
