using UnityEngine;

namespace HypaGames.AnimalTopGun
{

    // Properties:
    // have a life cycle dependent on pool
    public class ShotPooled : MonoBehaviour
    {
        private ShotPool _shotPool;
        private Tracker _tracker;

        [SerializeField]
        private float maxLifeTime = 5f;
        private float lifeTime;

        public void Init(ShotPool shotPool)
        {
            _shotPool = shotPool;
        }
        
        public void InitTracker(Tracker tracker)
        {
            _tracker = tracker;
            _tracker.AddToTrack();
        }

        private void OnEnable()
        {
            lifeTime = 0f;

        }

        public void Update()
        {
            lifeTime += Time.deltaTime;
            if (lifeTime > maxLifeTime)
            {
                if (_tracker)
                {
                    _tracker.RemoveFromTrack();
                }
                _shotPool.ReturnToPool(this);
            }
        }
    }

}