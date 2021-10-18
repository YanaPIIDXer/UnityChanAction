using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy.State
{
    /// <summary>
    /// エネミーステート：接近
    /// </summary>
    public class EnemyStateApproach : EnemyState
    {
        /// <summary>
        /// 接近するプレイヤーキャラ
        /// </summary>
        private Player.Player targetPlayer = null;

        /// <summary>
        /// このステートに最低でも滞在しなければならない時間
        /// </summary>
        private float stayTime = 1.0f;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enemy">各Componentアクセス用インタフェース</param>
        /// <param name="targetPlayer">接近するプレイヤーキャラ</param>
        public EnemyStateApproach(IEnemy enemy, Player.Player targetPlayer)
            : base(enemy)
        {
            this.targetPlayer = targetPlayer;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            stayTime -= Time.deltaTime;
            var dist = targetPlayer.transform.position - Enemy.Transform.position;
            dist.y = 0;
            if (dist.sqrMagnitude < 400.0f && stayTime <= 0.0f)
            {
                Enemy.State.SetNextState(new EnemyStateNutral(Enemy));
                Enemy.AI.Resume();
                return;
            }

            dist.Normalize();
            Enemy.Move.MoveVector = new Vector2(dist.x, dist.z);
        }
    }
}
