using UnityEngine;
using System.Collections.Generic;
using MEC;

namespace HypaGames.AnimalTopGun
{
    public class ExplosionPooled : MonoBehaviour
    {
        [SerializeField]
        private float _disableTime;
        private float _nextDisableTime;

        [SerializeField]
        private List<ParticleSystem> _particles;

        private ExplosionPool _explosionPool;

        public void Init(ExplosionPool explosionPool)
        {
            _explosionPool = explosionPool;
            _nextDisableTime = Time.time + _disableTime;
        }

        private void OnEnable()
        {
            foreach(var particle in _particles)
            {
                particle.Play();
            }            
        }

        private void Update()
        {
            if(_nextDisableTime <= Time.time)
            {
                _explosionPool.ReturnToPool(this);
            }
        }
    }

}