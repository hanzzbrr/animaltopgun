using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class Tracker : MonoBehaviour
    {
        private int _trackedCount;

        public void AddToTrack()
        {
            _trackedCount++;
        }

        public void RemoveFromTrack()
        {
            _trackedCount--;
        }

        private void Update()
        {
            Debug.Log(_trackedCount);
        }
    }
}
