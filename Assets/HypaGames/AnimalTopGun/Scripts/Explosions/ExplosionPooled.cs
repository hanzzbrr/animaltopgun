using UnityEngine;
using System.Collections.Generic;
using MEC;

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
            Timing.RunCoroutine(_DisableAfterTime());
        }

        private IEnumerator<float> _DisableAfterTime()
        {
            yield return Timing.WaitForSeconds(_disableTime);
            _explosionPool.ReturnToPool(this);
        }
    }

}