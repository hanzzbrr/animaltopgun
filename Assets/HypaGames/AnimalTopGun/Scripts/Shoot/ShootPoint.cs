using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

namespace HypaGames.AnimalTopGun
{

    // Properties:
    // Creating objects per time
    // can create as infinitive objects as enless count
    // all objects move linear
    // use pools
    public class ShootPoint : MonoBehaviour
    {
        [System.NonSerialized]
        public bool IsTracked;
        private Tracker _tracker;

        [SerializeField]
        private bool _isInfinite = true;
        public int _maxShots;
        private int _shotCount = 0;

        [SerializeField]
        private ShotPool shotPool;

        public float fireRate = 0.1f;
        private float nextFire;

        public float bulletSpeed;

        TransformAccessArray transforms;
        MovementJob moveJob;
        JobHandle moveHandle;

        private void OnEnable()
        {
            if (IsTracked)
            {
                _tracker = FindObjectOfType<Tracker>();
            }
            transforms = new TransformAccessArray(0, -1);
        }


        private void Update()
        {
            if (_isInfinite)
            {
                PerformShoot();
            }
            else
            {
                if (_shotCount < _maxShots)
                {
                    PerformShoot();
                }
            }


            moveHandle.Complete();

            moveJob = new MovementJob()
            {
                moveSpeed = bulletSpeed,
                deltaTime = Time.deltaTime
            };

            moveHandle = moveJob.Schedule(transforms);

            JobHandle.ScheduleBatchedJobs();
        }

        void OnDisable()
        {
            moveHandle.Complete();
            transforms.Dispose();
        }

        private void PerformShoot()
        {
            if (Time.time > nextFire)
            {
                if (!_isInfinite)
                {
                    _shotCount++;
                }
                bool newCreated = false;

                moveHandle.Complete();

                nextFire = Time.time + fireRate;
                ShotPooled shotPooled = shotPool.Get(out newCreated);
                if (newCreated)
                {
                    transforms.Add(shotPooled.transform);
                    shotPooled.Init(shotPool);
                }
                if (_tracker)
                {
                    shotPooled.InitTracker(_tracker);
                }
                shotPool.ActivateObject(shotPooled.gameObject);

                transforms.capacity = shotPool.GetPoolCount();

                shotPooled.transform.position = transform.position;
                shotPooled.transform.rotation = transform.rotation;
                //Debug.Log(newCreated + " length: " + transforms.length);
            }
        }

        public void DeactivateAllObjects()
        {
            shotPool.DeactivateAllObjects();
        }
    }

}