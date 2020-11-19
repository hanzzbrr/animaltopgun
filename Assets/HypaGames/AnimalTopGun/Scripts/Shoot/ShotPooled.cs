using UnityEngine;

namespace HypaGames.AnimalTopGun
{

    // Properties:
    // have a life cycle dependent on pool
    public class ShotPooled : MonoBehaviour
    {

        public ShotPool ShotPool;
        private Tracker _tracker;

        [SerializeField]
        private float maxLifeTime = 5f;
        private float lifeTime;

        public void Init(ShotPool shotPool)
        {
            ShotPool = shotPool;
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
                EndLife();
            }
        }

        public void EndLife()
        {
            if (_tracker)
            {
                _tracker.RemoveFromTrack();
            }
            ShotPool.ReturnToPool(this);
        }


    }

}