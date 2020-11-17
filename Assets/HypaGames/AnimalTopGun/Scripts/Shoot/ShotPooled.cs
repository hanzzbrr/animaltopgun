using UnityEngine;
using Lean.Pool;

public class ShotPooled : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 30f;    
    [SerializeField]
    private float maxLifeTime = 5f;

    private float lifeTime;

    private void OnEnable()
    {
        lifeTime = 0f;
    }
    public void Update()
    {
        transform.Translate(Vector3.forward * MoveSpeed, Space.World);

        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            ShotPool.Instance.ReturnToPool(this);
        }
    }
}
