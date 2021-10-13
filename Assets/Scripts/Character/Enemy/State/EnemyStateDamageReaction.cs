using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy.State
{
    /// <summary>
    /// エネミーステート：ダメージ反応
    /// </summary>
    public class EnemyStateDamageReaction : EnemyState
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enemy">各Componentを参照するためのインタフェース</param>
        public EnemyStateDamageReaction(IEnemy enemy)
            : base(enemy)
        {
        }

        /// <summary>
        /// 動けるか？
        /// </summary>
        public override bool IsMovable => false;

        /// <summary>
        /// ステート再生時間閾値（最低滞在時間）
        /// </summary>
        private float ThresholdTime = 0.5f;

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            ThresholdTime -= Time.deltaTime;
            if (ThresholdTime <= 0.0f && Enemy.Animation.IsNutralState)
            {
                Enemy.State.SetNextState(new EnemyStateNutral(Enemy));
            }
        }
    }
}
