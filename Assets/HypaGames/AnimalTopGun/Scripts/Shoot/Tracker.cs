using UnityEngine;
using UnityEngine.Events;

namespace HypaGames.AnimalTopGun
{
    public class Tracker : MonoBehaviour
    {
        public bool AreEnemiesLeft { private set; get; }

        [System.NonSerialized]
        public UnityEvent NoEnemiesLeft;

        private int _trackedCount;

        private void OnEnable()
        {
            AreEnemiesLeft = false;
        }

        private void OnDisable()
        {
            
        }

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
                AreEnemiesLeft = true;
                Debug.Log("Wave ended");
            }
        }

    }
}
