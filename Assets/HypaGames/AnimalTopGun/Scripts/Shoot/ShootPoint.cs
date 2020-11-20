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

        TransformAccessArray transforms;
        MovementJob moveJob;
        JobHandle moveHandle;

        private void OnEnable()
        {
            transforms = new TransformAccessArray(0, -1);
        }


        private void Update()
        {
            PerformShot();
            PerformMove();
        }

        void OnDisable()
        {
            FinishMove();
        }

        private void FinishMove()
        {
            moveHandle.Complete();
            transforms.Dispose();
        }

        private void PerformMove()
        {
            moveHandle.Complete();

            moveJob = new MovementJob()
            {
                moveSpeed = bulletSpeed,
                deltaTime = Time.deltaTime
            };

            moveHandle = moveJob.Schedule(transforms);

            JobHandle.ScheduleBatchedJobs();
        }

        private void PerformShot()
        {
            if (Time.time > _nextShotTime)
            {
                bool newCreated = false;

                moveHandle.Complete();

                _nextShotTime = Time.time + fireRate;
                ShotPooled shotPooled = shotPool.Get(out newCreated);
                if (newCreated)
                {
                    transforms.Add(shotPooled.transform);
                    shotPooled.Init(shotPool);
                }
                shotPool.ActivateObject(shotPooled.gameObject);

                transforms.capacity = shotPool.GetPoolCount();

                shotPooled.transform.position = transform.position;
                shotPooled.transform.rotation = transform.rotation;
            }
        }
    }

}