using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class PrefabData : MonoBehaviour
    {
        public GameObject PigPrefab;
        public GameObject CowPrefab;
        public GameObject BigCowPrefab;
        public GameObject BossPrefab;

        public GameObject GetPrefab(EnemyTypeConsts enemyTypeConsts)
        {
            switch (enemyTypeConsts)
            {
                case EnemyTypeConsts.Pig:
                    return PigPrefab;
                case EnemyTypeConsts.Cow:
                    return CowPrefab;
                case EnemyTypeConsts.BigCow:
                    return BigCowPrefab;
                case EnemyTypeConsts.Boss:
                    return BossPrefab;
                default:
                    return null;
            }
        }
    }
}
