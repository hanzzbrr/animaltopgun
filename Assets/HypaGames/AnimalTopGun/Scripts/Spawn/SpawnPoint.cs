using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Zenject;
using Unity.Collections;

namespace HypaGames.AnimalTopGun
{
    public class SpawnPoint : MonoBehaviour
    {
        public GameObject _prefab;
        public float SpawnCount;
        public float DelayPerSpawn;

        private LevelGeneration.IPlayArea _playArea;
        private bool _spawnStarted;

        [Inject]
        public void Construct(LevelGeneration.IPlayArea playArea)
        {
            _playArea = playArea;
        }

        private void Awake()
        {
            if (!_prefab.GetComponent<SpawnedObject>())
            {
                Debug.LogError("There is no SpawnedObject component attached to: " + _prefab.name);
                Debug.Break();
            }
        }

        private void Update()
        {
            if (_spawnStarted)
            {
                return;
            }


            //if(_playArea.GetFrontPos() >= transform.position.z)
            //{
            //    Debug.Log("New Spawn");
            //    OnNewSpawnIterationReached();
            //}


        }

        private void OnGUI()
        {
            if (GUILayout.Button("Start"))
            {
                OnNewSpawnIterationReached();
            }
        }


        public void OnNewSpawnIterationReached()
        {
            _spawnStarted = true;
            StartCoroutine(StartSpawning());
        }

        IEnumerator StartSpawning()
        {
            for(int i=0; i< SpawnCount; i++)
            {
                GameObject newSpawnedObject = Lean.Pool.LeanPool.Spawn(_prefab, transform.position, Quaternion.identity, null);
                SpawnedObject spawnedObject = newSpawnedObject.GetComponent<SpawnedObject>();
                yield return new WaitForSeconds(DelayPerSpawn);
            }
        }

        public void Despawn()
        {

        }
    }
}
