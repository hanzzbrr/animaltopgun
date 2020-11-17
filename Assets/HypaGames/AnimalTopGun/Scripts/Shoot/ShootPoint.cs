using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] 
    private float fireRate = 0.1f;
    private float nextFire;

    [SerializeField]
    private float bulletSpeed;

    TransformAccessArray transforms;
    MovementJob moveJob;
    JobHandle moveHandle;

    private void Start()
    {
        transforms = new TransformAccessArray(0, -1);
    }


    private void Update()
    {
        PerformShoot();

        moveHandle.Complete();

        moveJob = new MovementJob()
        {
            moveSpeed = bulletSpeed,
            deltaTime = Time.deltaTime
        };

        moveHandle = moveJob.Schedule(transforms);

        JobHandle.ScheduleBatchedJobs();
    }

    void OnDisable()
    {
        moveHandle.Complete();
        transforms.Dispose();
    }

    private void PerformShoot()
    {
        if (Time.time > nextFire)
        {
            bool newCreated = false;

            moveHandle.Complete();

            nextFire = Time.time + fireRate;
            ShotPooled shotPooled =  ShotPool.Instance.Get(out newCreated);
            ShotPool.Instance.ActivateObject(shotPooled.gameObject);

            transforms.capacity = ShotPool.Instance.GetPoolCount();

            shotPooled.transform.position = transform.position;
            shotPooled.transform.rotation = transform.rotation;

            if (newCreated)
            {
                transforms.Add(shotPooled.transform);
            }
            //Debug.Log(newCreated + " length: " + transforms.length);
        }
    }
}
