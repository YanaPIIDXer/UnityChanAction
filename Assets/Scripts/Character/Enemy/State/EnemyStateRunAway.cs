using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy.State
{
    /// <summary>
    /// エネミーステート：逃走
    /// </summary>
    public class EnemyStateRunAway : EnemyState
    {
        /// <summary>
        /// 対象となるプレイヤー
        /// </summary>
        private Player.Player targetPlayer = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enemy">各Componentへの参照</param>
        /// <param name="targetPlayer">対象となるプレイヤー</param>
        public EnemyStateRunAway(IEnemy enemy, Player.Player targetPlayer)
            : base(enemy)
        {
            this.targetPlayer = targetPlayer;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            var moveVec = Enemy.Transform.position - targetPlayer.transform.position;
            moveVec.y = 0.0f;
            Enemy.Move.MoveVector = moveVec.normalized;
        }
    }
}
