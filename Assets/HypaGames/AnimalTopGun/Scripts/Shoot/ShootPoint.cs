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
        [Header("Stay in player area options")]
        [SerializeField]
        private bool _stayInPlayerArea;
        [SerializeField]
        private PlayerController _player;
        [SerializeField]
        private float _playerZOffset;

        [Header("Tracker options")]
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
        private float _nextSpawnTime;

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
            if (_stayInPlayerArea)
            {
                _player = FindObjectOfType<PlayerController>();
            }
            transforms = new TransformAccessArray(0, -1);
        }


        private void Update()
        {
            if (_isInfinite)
            {
                PerformSpawn();
            }
            else
            {
                if (_shotCount < _maxShots)
                {
                    PerformSpawn();
                }
            }

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

            if (_stayInPlayerArea)
            {

            }
        }

        private void PerformSpawn()
        {
            if (Time.time > _nextSpawnTime)
            {
                if (!_isInfinite)
                {
                    _shotCount++;
                }
                bool newCreated = false;

                moveHandle.Complete();

                _nextSpawnTime = Time.time + fireRate;
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
    }

}