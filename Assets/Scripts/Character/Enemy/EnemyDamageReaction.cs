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

                    if (!bIsDead)
                    {
                        enemyComponents.Animation.PlayDamageMotion();
                    }
                    break;

                case ReactionType.Blow:

                    enemyComponents.Move.AddForce(blowVector * collisionData.ReactionPower);
                    if (!bIsDead)
                    {
                        enemyComponents.Animation.PlayBlowMotion();
                    }
                    break;

                case ReactionType.Lift:

                    enemyComponents.Move.AddForce(Vector3.up * collisionData.ReactionPower);
                    if (!bIsDead)
                    {
                        enemyComponents.Animation.PlayBlowMotion();
                    }
                    break;
            }

            if (bIsDead)
            {
                ToRagdoll();
                enemyComponents.State.SetNextState(new EnemyStateDead(enemyComponents));
            }
            else
            {
                enemyComponents.State.SetNextState(new EnemyStateDamageReaction(enemyComponents));
            }
        }

        /// <summary>
        /// ラグドール化
        /// </summary>
        private void ToRagdoll()
        {
            GetComponent<Animator>().enabled = false;
            var rigidBodies = GetComponentsInChildren<Rigidbody>();
            foreach (var rigidBody in rigidBodies)
            {
                rigidBody.isKinematic = false;
            }

            var colliders = GetComponentsInChildren<Collider>();
            foreach (var collider in colliders)
            {
                collider.isTrigger = false;
            }
        }
    }
}
