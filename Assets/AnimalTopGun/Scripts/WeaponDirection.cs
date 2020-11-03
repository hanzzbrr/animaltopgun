using UnityEngine;

namespace AnimalTopGun.Scripts
{
    public class WeaponDirection : MonoBehaviour
    {
        public Transform FrontPoint;
        public Transform BackPoint;
        public Transform TouchPoint;

        public Vector3 GetDirectionNormalized()
        {
            return (FrontPoint.position - BackPoint.position).normalized;            
        }
    }
}
