using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;
using HelpersLib.Scripts;

namespace HypaGames.AnimalTopGun
{

    // Properties:
    // Creating objects per time
    // can create as infinitive objects as enless count
    // all objects move linear
    // use pools
    public class ShootPoint : MonoBehaviour
    {
        [SerializeField]
        private ShotPool shotPool;

        public float fireRate = 0.1f;
        private float _nextShotTime;

        public float bulletSpeed;

        private void Update()
        {
            PerformShot();        
        }

        private void PerformShot()
        {
            if (Time.time > _nextShotTime)
            {
                _nextShotTime = Time.time + fireRate;
                ShotPooled shotPooled = shotPool.Get();
                shotPooled.BulletSpeed = bulletSpeed;
                shotPooled.Init(shotPool);
                shotPooled.enabled = true;
                shotPool.ActivateObject(shotPooled.gameObject);

                shotPooled.transform.position = transform.position;
                shotPooled.transform.rotation = transform.rotation;
            }
        }
    }

}