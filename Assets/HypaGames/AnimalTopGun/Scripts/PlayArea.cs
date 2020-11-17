using UnityEngine;
using HypaGames.LevelGeneration;

namespace HypaGames.AnimalTopGun
{
    public class PlayArea : MonoBehaviour, IPlayArea
    {
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