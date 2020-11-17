using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Zenject;

namespace HypaGames.AnimalTopGun
{
    public class SpawnedObject : MonoBehaviour
    {
        // is defined in inspector via .assets
        public BaseMoveStrategy MoveStrategy;
        public float MoveSpeed;

        private PlayArea _playArea;

        public void Init(PlayArea playArea)
        {
            _playArea = playArea;
            StartCoroutine(UpdateCoroutine());
        }

        public void Init(SpawnPoint spawnPoint)
        {
            StartCoroutine(UpdateCoroutine());
        }

        public float lifeTime;
        private void Awake()
        {
            OnPlayAreaExit();
        }

        private IEnumerator UpdateCoroutine()
        {
            while (_playArea.GetEndPos() <= transform.position.z)
            {
                PerformMove();
                yield return new WaitForEndOfFrame();
            }
            OnPlayAreaExit();
        }

        public void PerformMove()
        {
            MoveStrategy.PerformMove(transform, MoveSpeed);
        }

        public void OnPlayAreaExit()
        {
            Lean.Pool.LeanPool.Despawn(gameObject, 0);
        }
    }
}
