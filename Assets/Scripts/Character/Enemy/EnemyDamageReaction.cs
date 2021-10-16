using System.Collections;
using System.Collections.Generic;
using Character.Enemy.State;
using Collision;
using Master;
using UnityEngine;

namespace Character.Enemy
{
    /// <summary>
    /// エネミーのダメージリアクション
    /// </summary>
    public class EnemyDamageReaction : MonoBehaviour
    {
        /// <summary>
        /// EnemyComponentにアクセスするためのインタフェース
        /// </summary>
        private IEnemy enemyComponents = null;

        void Awake()
        {
            enemyComponents = GetComponent<IEnemy>();
        }
        /// <summary>
        /// ダメージを受けた
        /// </summary>
        /// <param name="collisionData">コリジョンデータ</param>
        /// <param name="blowVector">「吹き飛び」の場合の吹き飛びベクトル</param>
        /// <param name="bIsDead">死んだか？</param>
        public void OnDamaged(CollisionData collisionData, Vector3 blowVector, bool bIsDead)
        {
            switch (collisionData.ReactionType)
            {
                case ReactionType.None:

                    enemyComponents.Animation.PlayDamageMotion();
                    break;

                case ReactionType.Blow:

                    enemyComponents.Move.AddForce(blowVector * collisionData.ReactionPower);
                    enemyComponents.Animation.PlayBlowMotion();
                    break;

                case ReactionType.Lift:

                    enemyComponents.Move.AddForce(Vector3.up * collisionData.ReactionPower);
                    enemyComponents.Animation.PlayBlowMotion();
                    break;
            }

            enemyComponents.State.SetNextState(new EnemyStateDamageReaction(enemyComponents));
        }
    }
}
