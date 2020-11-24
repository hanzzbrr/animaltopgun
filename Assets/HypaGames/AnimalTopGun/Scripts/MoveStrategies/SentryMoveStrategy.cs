using UnityEngine;
using HelpersLib.Scripts;

namespace HypaGames.AnimalTopGun
{
    [CreateAssetMenu(menuName = "Hypa Games/Sentry Move Strategy")]
    public class SentryMoveStrategy : BaseMoveStrategy
    {
        PlayableArea PlayableArea;
        [SerializeField]
        float zOffset;

        [SerializeField]
        Vector2 zOffsetBorders;
        [SerializeField]
        Vector2 xOffsetBorders;

        float randomZOffset = 0;
        float randomXOffset = 0;

        Vector3 _target;
        private void OnEnable()
        {
            PlayableArea = FindObjectOfType<PlayableArea>();

        }

        public override void PerformMove(Transform originTransform, float speed)
        {
            Vector3 target = new Vector3(
                PlayableArea.transform.position.x + randomXOffset,
                PlayableArea.transform.position.y,
                PlayableArea.transform.position.z + zOffset + randomZOffset
                );



            originTransform.position = Vector3.MoveTowards(
                originTransform.position,
                target,
                speed * Time.deltaTime);

            if (Vector3.Distance(originTransform.position, target) < 1f)
            {
                randomXOffset = Random.Range(xOffsetBorders.x, xOffsetBorders.y);
                randomZOffset = Random.Range(zOffsetBorders.x, zOffsetBorders.y);
                Debug.Log("New target: ");
            }
            //Debug.Log("pig: " + originTransform.position + " target: " + target);

        }
    }
}
