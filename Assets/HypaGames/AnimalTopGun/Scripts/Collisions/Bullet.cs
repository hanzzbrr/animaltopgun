using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        ShotPooled _shotPooled;

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Enemy")
            {
                _shotPooled.EndLife();
            }
        }
    }
}
