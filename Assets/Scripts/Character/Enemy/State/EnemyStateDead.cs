using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy.State
{
    /// <summary>
    /// エネミーステート：死亡
    /// </summary>   
    public class EnemyStateDead : EnemyState
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enemy">各Componentを取得するためのインタフェース</param>
        public EnemyStateDead(IEnemy enemy)
            : base(enemy)
        {
        }

        /// <summary>
        /// 移動可能か？
        /// </summary>
        public override bool IsMovable => false;

        /// <summary>
        /// ステート変更可能か？
        /// </summary>
        public override bool IsStateChangeable => false;
    }
}
