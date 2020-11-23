using UnityEngine;
using System.Collections;

namespace HypaGames.AnimalTopGun
{
    public class SpawnedPooled : MonoBehaviour
    {
        private Tracker _tracker;

        private SpawnPool _spawnPool;
        private float _spawnedSpeed;

        private float _maxLifeTime = 5f;
        private float lifeTime;

        public void Init(SpawnPool spawnPool, float maxLifeTime)
        {
            _maxLifeTime = maxLifeTime;
            _spawnPool = spawnPool;
        }

        public void InitTracker(Tracker tracker)
        {
            _tracker = tracker;
        }

        private void OnEnable()
        {
            lifeTime = 0f;

        }

        public void Update()
        {
            lifeTime += Time.deltaTime;
            if (lifeTime > _maxLifeTime)
            {
                EndLife();
            }
        }

        public void EndLife()
        {
            if (_tracker)
            {
                _tracker.RemoveFromTrack();
            }
            _spawnPool.ReturnToPool(this);
        }
    }
}