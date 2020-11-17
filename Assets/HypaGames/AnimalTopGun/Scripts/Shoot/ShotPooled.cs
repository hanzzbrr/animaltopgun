using UnityEngine;

public class ShotPooled : MonoBehaviour
{
    [SerializeField]
    private float maxLifeTime = 5f;
    private float lifeTime;

    private void OnEnable()
    {
        lifeTime = 0f;
    }

    public void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            ShotPool.Instance.ReturnToPool(this);
        }
    }
}
