using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class Spawner : MonoBehaviour
    {        
        // init values
        private SpawnPool _spawnPool;
        private bool _isTracked;
        private bool _isInfinite;
        private int _maxSpawns;
        private float _spawnRate = 0.1f;
        private float _spawnedSpeed;

        private Tracker _tracker;
        private int _spawnCounter = 0;
        private float _nextSpawnTime;
        private float _spawnedMaxLifeTime;
        private float _waveHp;
        private float _startYAngle;

        public void InitSpawner(bool isTracked, bool isInfinite, int maxSpawns, float spawnRate, float spawnedSpeed, SpawnPool spawnPool, float spawnedMaxLifeTime, float waveHp, float startYAngle)
        {
            _isTracked = isTracked;
            _isInfinite = isInfinite;
            _maxSpawns = maxSpawns;
            _spawnRate = spawnRate;
            _spawnedSpeed = spawnedSpeed;
            _spawnPool = spawnPool;
            _spawnedMaxLifeTime = spawnedMaxLifeTime;
            _waveHp = waveHp;
            _startYAngle = startYAngle;
        }

        private void OnEnable()
        {
            if (_isTracked)
            {
                _tracker = FindObjectOfType<Tracker>();
                _tracker.AddToTrack(_maxSpawns);
            }
        }


        private void Update()
        {
            if (_isInfinite)
            {
                PerformSpawn();
            }
            else
            {
                if (_spawnCounter < _maxSpawns)
                {
                    PerformSpawn();
                }
            }
        }

        private void PerformSpawn()
        {
            if (Time.time > _nextSpawnTime)
            {
                if (!_isInfinite)
                {
                    _spawnCounter++;
                }

                _nextSpawnTime = Time.time + _spawnRate;
                SpawnedPooled spawnedObject = _spawnPool.Get();
                IHealthContainer iHealthContainer = spawnedObject.GetComponent<IHealthContainer>();
                if (iHealthContainer != null)
                {
                    iHealthContainer.SetHP(_waveHp);
                }
                ISpeedContainer iSpeedContainer = spawnedObject.GetComponent<ISpeedContainer>();
                if (iSpeedContainer != null)
                {
                    iSpeedContainer.SetSpeed(_spawnedSpeed);
                }


                spawnedObject.Init(_spawnPool, _spawnedMaxLifeTime);

                if (_tracker)
                {
                    spawnedObject.InitTracker(_tracker);
                }
                _spawnPool.ActivateObject(spawnedObject.gameObject);

                spawnedObject.transform.position = transform.position;
                Vector3 eulerRotaion = new Vector3(
                    spawnedObject.transform.eulerAngles.x,
                    _startYAngle,
                    spawnedObject.transform.eulerAngles.z
                    );
                spawnedObject.transform.rotation = Quaternion.Euler(eulerRotaion);
            }
        }


    }
}
