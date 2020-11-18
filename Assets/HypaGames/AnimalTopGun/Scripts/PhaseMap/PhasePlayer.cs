using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class PhasePlayer : MonoBehaviour
    {
        public PhaseMapScriptableObject PhaseMap;
        private PhaseScriptableObject CurrentPhase;

        private float _nextPhaseTimer;
        private int _currentPhaseIndex;

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
            CurrentPhase = PhaseMap.PhaseMap[_currentPhaseIndex];
            if (CurrentPhase.PhaseType == PhaseType.Rest)
            {
                _nextPhaseTimer = Time.time + CurrentPhase.TimeDuration;
            }
            else if (CurrentPhase.PhaseType == PhaseType.Fight)
            {

            }
            else if (CurrentPhase.PhaseType == PhaseType.Boss)
            {

            }
        }

        private void PlayMap()
        {
            // 3 exit conditions:
            // time, all enemies destroyed or exit, boss destroyed

            if(CurrentPhase.PhaseType == PhaseType.Rest)
            {

            }
            else if(CurrentPhase.PhaseType == PhaseType.Fight)
            {

            }
            else if(CurrentPhase.PhaseType == PhaseType.Boss)
            {

            }
        }
    }
}
