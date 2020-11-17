using UnityEngine;

namespace HypaGames.AnimalTopGun
{

    public class WeaponHolder : MonoBehaviour
    {
        public Transform LeftHand;
        public Transform RightHand;

        public GameObject GunPrefab;

        private void Awake()
        {
            //SpawnGun();
        }

        private void SpawnGun()
        {
            GameObject leftHandGun = GameObject.Instantiate(GunPrefab, transform);
            leftHandGun.transform.position = LeftHand.transform.position;
            WeaponDirection leftHandDirection = leftHandGun.GetComponent<WeaponDirection>();
            leftHandGun.transform.rotation = Quaternion.LookRotation(leftHandDirection.GetDirectionNormalized());

            GameObject rightHandGun = GameObject.Instantiate(GunPrefab, transform);
            rightHandGun.transform.position = RightHand.transform.position;
            WeaponDirection rightHandDirection = rightHandGun.GetComponent<WeaponDirection>();
            rightHandGun.transform.rotation = Quaternion.LookRotation(rightHandDirection.GetDirectionNormalized());
        }
    }
}
