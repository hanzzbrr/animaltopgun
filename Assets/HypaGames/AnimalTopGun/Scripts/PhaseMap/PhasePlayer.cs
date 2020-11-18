using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class PhasePlayer : MonoBehaviour
    {
        [SerializeField]
        private Tracker _tracker;

        [SerializeField]
        private float _trackerDelay = 2.5f;

        public PhaseMapScriptableObject PhaseMap;
        private PhaseScriptableObject CurrentPhase;

        private float _nextPhaseTime;
        private int _currentPhaseIndex = -1;

        private void OnEnable()
        {
            InitPhase();
        }

        private void Update()
        {
            PlayMap();
        }

        private void InitPhase()
        {
            _currentPhaseIndex++;
            CurrentPhase = PhaseMap.PhaseMap[_currentPhaseIndex];
            Debug.Log("CurrentPhase: " + CurrentPhase.PhaseName + " : " + CurrentPhase.PhaseType);
            if (CurrentPhase.PhaseType == PhaseType.Rest)
            {
                _nextPhaseTime = Time.time + CurrentPhase.TimeDuration;
            }
            else if (CurrentPhase.PhaseType == PhaseType.Fight)
            {
                _tracker.NoEnemiesLeft.AddListener(OnWaveEnded);
            }
            else if (CurrentPhase.PhaseType == PhaseType.Boss)
            {
                _tracker.NoEnemiesLeft.AddListener(OnWaveEnded);
            }
        }

        private void OnWaveEnded()
        {
            _nextPhaseTime = Time.time + _trackerDelay;
        }

        private void PlayMap()
        {
            if(Time.time > _nextPhaseTime)
            {
                InitPhase();
            }
        }
    }
}
