using UnityEngine;
using UnityEngine.Events;

namespace HypaGames.AnimalTopGun
{
    public class Tracker : MonoBehaviour
    {
        public UnityEvent NoEnemiesLeft;

        private int _trackedCount;

        public void AddToTrack()
        {
            _trackedCount++;
            Debug.Log(_trackedCount);
        }

        public void RemoveFromTrack()
        {
            _trackedCount--;
            Debug.Log(_trackedCount);
            if(_trackedCount == 0)
            {
                NoEnemiesLeft.Invoke();
                Debug.Log("Wave ended");
            }
        }

    }
}
