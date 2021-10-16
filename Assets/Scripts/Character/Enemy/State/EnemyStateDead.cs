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
        /// <param name="enemyObject">エネミーのGameObject</param>
        public EnemyStateDead(IEnemy enemy, GameObject enemyObject)
            : base(enemy)
        {
            this.enemyObject = enemyObject;
        }

        /// <summary>
        /// 消滅までのタイマー
        /// </summary>
        private float removeTimer = 5.0f;

        /// <summary>
        /// エネミーのGameObject
        /// </summary>
        private GameObject enemyObject = null;

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            if (removeTimer <= 0.0f) { return; }

            removeTimer -= Time.deltaTime;
            if (removeTimer <= 0.0f)
            {
                GameObject.Destroy(enemyObject);
            }
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
