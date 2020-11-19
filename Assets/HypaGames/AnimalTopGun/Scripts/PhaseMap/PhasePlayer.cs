using UnityEngine;
using System.Collections;
using HelpersLib.Scripts;
using System.Linq;

namespace HypaGames.AnimalTopGun
{
    public class PhasePlayer : MonoBehaviour
    {
        [SerializeField]
        private Tracker _tracker;

        [SerializeField]
        private PlayableArea _playableArea;

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

        private void OnDisable()
        {
            Debug.Log("Map Ended");
        }

        private void InitPhase()
        {
            _currentPhaseIndex++;
            if(_currentPhaseIndex == PhaseMap.PhaseMap.Count)
            {
                this.enabled = false;
                return;
            }

            CurrentPhase = PhaseMap.PhaseMap[_currentPhaseIndex];
            if (CurrentPhase.PhaseType == PhaseType.Rest)
            {
                StartCoroutine(PlayRestPhase());
            }
            else if (CurrentPhase.PhaseType == PhaseType.Fight)
            {
                StartCoroutine(FightPhase());
            }
        }

        private void OnWaveEnded()
        {
            _nextPhaseTime = Time.time + _trackerDelay;
        }

        private IEnumerator PlayRestPhase()
        {
            _nextPhaseTime = Time.time + CurrentPhase.TimeDuration;
            Debug.Log("Phase BEGIN: " + CurrentPhase.name);
            while (Time.time < _nextPhaseTime)
            {
                Debug.Log("Time: " + Time.time + " nexPhase: " + _nextPhaseTime);
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("End of phase");
            InitPhase();            
        }

        private IEnumerator FightPhase()
        {
            _tracker.enabled = true;           

            foreach(var enemyWave in CurrentPhase.EnemyWave)
            {
                GameObject newWave = Instantiate(enemyWave.EnemySpawnerPrefab);
                newWave.transform.position = new Vector3(
                    _playableArea.transform.position.x + enemyWave.XOffset,
                    _playableArea.transform.position.y + enemyWave.YOffset,
                    _playableArea.LengthBorder.x + enemyWave.ZOffset
                    );
                ShootPoint shootPoint = newWave.GetComponent<ShootPoint>();
                shootPoint.IsTracked = enemyWave.IsTracked;
                shootPoint.fireRate = enemyWave.WaveRate;
                shootPoint.bulletSpeed = enemyWave.WaveSpeed;
                shootPoint._maxShots = enemyWave.Count;
                shootPoint.enabled = true;             
                
            }

            Debug.Log("Phase begin: " + CurrentPhase.name);
            while (_tracker.AreEnemiesLeft)
            {
                yield return new WaitForEndOfFrame();
            }
            if(CurrentPhase.EnemyWave.Any(wave => wave.IsBossPhase))
            {
                Debug.Log("Destroy all enemies sygnal");
                Debug.Break();
            }
            Debug.Log("End of phase: " + CurrentPhase.name);
            _tracker.enabled = false;
            InitPhase();
        }
    }
}
