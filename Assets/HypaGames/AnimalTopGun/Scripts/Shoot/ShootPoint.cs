using UnityEngine;
using System.Collections;
using Lean.Pool;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] 
    private float fireRate = 0.1f;
    private float nextFire;


    public void Update()
    {
        PerformShoot();
    }

    public void PerformShoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ShotPooled shotPooled =  ShotPool.Instance.Get();
            ShotPool.Instance.ActivateObject(shotPooled.gameObject);
            shotPooled.transform.position = transform.position;
            shotPooled.transform.rotation = transform.rotation;
        }
    }
}
