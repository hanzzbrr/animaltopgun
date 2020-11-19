using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    [CreateAssetMenu(fileName = "EnemyWave", menuName = "Hypa Games/Enemy Wave", order = 1)]
    [System.Serializable]
    public class EnemyWaveScriptableObject : ScriptableObject
    {
        public GameObject EnemySpawnerPrefab;
        public int Count;
        public float XOffset;
        public float YOffset;
        public float ZOffset;
        public float Delay;
        public float YAngle;
    }
}
