﻿using UnityEngine;
using HypaGames.LevelGeneration.Scripts;
using System.Collections;

namespace HypaGames.AnimalTopGun
{
    public class PlayArea : MonoBehaviour, IPlayArea
    {
        [SerializeField]
        private PhasePlayer _phasePlayer;

        public float Width;
        public float Length;
        public float Speed;

        public float GetFrontPos()
        {
            return transform.position.z + Length;
        }
        public float GetEndPos()
        {
            return transform.position.z - Length;
        }
        private void Awake()
        {

        }
        
        public void BossPhaseStarted()
        {
            StartCoroutine(ClampSpeed());
        }
        float normalSpeed;
        private IEnumerator ClampSpeed()
        {
            normalSpeed = Speed;
            float t = 0.0f;
            while(Speed > 0)
            {
                t += 0.1f * Time.deltaTime;
                Speed = Mathf.Lerp(Speed, 0, t);
                yield return new WaitForEndOfFrame();
            }            
        }

        private void Update()
        {
            PerformMove();
        }

        private void PerformMove()
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.World);
        }

    }
}