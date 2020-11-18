using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace HypaGames.AnimalTopGun
{
    public enum PhaseType { Rest, Fight, Boss }

    [CreateAssetMenu(fileName = "Phase", menuName = "Hypa Games/Phase", order = 1)]
    [System.Serializable]
    public class PhaseScriptableObject : ScriptableObject
    {
        [SerializeField]
        private string _phaseName;

        public List<EnemyWaveScriptableObject> EnemyWave;
        public PhaseType PhaseType;
        public float TimeDuration;

        public string PhaseName { get => _phaseName; }
    }
}