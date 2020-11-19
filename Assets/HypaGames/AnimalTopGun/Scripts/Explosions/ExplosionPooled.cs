using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HypaGames.AnimalTopGun
{
    public class ExplosionPooled : MonoBehaviour
    {
        [SerializeField]
        private float _disableTime;

        [SerializeField]
        private List<ParticleSystem> _particles;

        private ExplosionPool _explosionPool;

        public void Init(ExplosionPool explosionPool)
        {
            _explosionPool = explosionPool;
        }

        private void OnEnable()
        {
            foreach(var particle in _particles)
            {
                particle.Play();
            }
            StartCoroutine(DisableAfterTime());
        }

        IEnumerator DisableAfterTime()
        {
            yield return new WaitForSeconds(_disableTime);
            _explosionPool.ReturnToPool(this);
        }
    }

}