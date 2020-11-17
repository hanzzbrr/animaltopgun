using UnityEngine;
using System.Collections.Generic;

public class ShootController : MonoBehaviour
{
    public List<ShootPoint> shootPoints;
    private void Update()
    {
        PerformShootFromAllGuns();
    }
    public void PerformShootFromAllGuns()
    {
        foreach(var shootPoint in shootPoints)
        {
            shootPoint.PerformShoot();
        }
    }
}
