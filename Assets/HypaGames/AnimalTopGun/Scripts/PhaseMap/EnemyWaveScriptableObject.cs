using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    [CreateAssetMenu(fileName = "EnemyWave", menuName = "Hypa Games/Enemy Wave", order = 1)]
    [System.Serializable]
    public class EnemyWaveScriptableObject : ScriptableObject
    {
        public bool IsTracked;
        public GameObject EnemySpawnerPrefab;
        public int Count;
        public float WaveSpeed;
        public float WaveRate;
        public float XOffset;
        public float YOffset;
        public float ZOffset;
        public float Delay;
        public float YAngle;

        public bool IsBossPhase;
    }
}
