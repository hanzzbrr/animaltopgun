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

        public void InitSpawner(bool isTracked, bool isInfinite, int maxSpawns, float spawnRate, float spawnedSpeed, SpawnPool spawnPool)
        {
            _isTracked = isTracked;
            _isInfinite = isInfinite;
            _maxSpawns = maxSpawns;
            _spawnRate = spawnRate;
            _spawnedSpeed = spawnedSpeed;
            _spawnPool = spawnPool;
        }

        private void OnEnable()
        {
            if (_isTracked)
            {
                _tracker = FindObjectOfType<Tracker>();
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
                spawnedObject.Init(_spawnPool);

                if (_tracker)
                {
                    spawnedObject.InitTracker(_tracker);
                }
                _spawnPool.ActivateObject(spawnedObject.gameObject);

                spawnedObject.transform.position = transform.position;
                spawnedObject.transform.rotation = transform.rotation;
            }
        }
    }
}
