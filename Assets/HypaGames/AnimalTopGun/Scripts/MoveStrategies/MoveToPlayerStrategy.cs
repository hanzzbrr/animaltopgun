using UnityEngine;
using HelpersLib.Scripts;

namespace HypaGames.AnimalTopGun
{
    [CreateAssetMenu(menuName = "Hypa Games/Move ToPlayer Strategy")]
    public class MoveToPlayerStrategy : BaseMoveStrategy
    {
        [SerializeField]
        PlayerController Player;

        private void OnEnable()
        {
            Player = FindObjectOfType<PlayerController>();
        }

        public override void PerformMove(Transform originTransform, float speed)
        {
            originTransform.position = Vector3.MoveTowards(
                originTransform.position, 
                Player.transform.position, 
                speed * Time.deltaTime);
        }
    }
}
