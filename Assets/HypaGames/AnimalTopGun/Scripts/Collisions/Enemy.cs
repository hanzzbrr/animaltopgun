using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class Enemy : MonoBehaviour
    {
        public int HP;

        [SerializeField]
        ShotPooled _shotPooled;

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
            // something like death animation
            _shotPooled.ReturnToPool();
        }
    }
}
