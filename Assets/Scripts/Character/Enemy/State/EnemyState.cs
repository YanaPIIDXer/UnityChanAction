using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy.State
{
    /// <summary>
    /// エネミーステート基底クラス
    /// </summary>
    public abstract class EnemyState
    {
        /// <summary>
        /// 各Componentへの参照用インタフェース
        /// </summary>
        protected IEnemy Enemy { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enemy">各Componentへの参照用インタフェース</param>
        public EnemyState(IEnemy enemy)
        {
            Enemy = enemy;
        }

        /// <summary>
        /// 開始処理
        /// </summary>
        public virtual void Begin() { }

        /// <summary>
        /// 更新処理
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// 終了処理
        /// </summary>
        public virtual void Terminate() { }
    }
}
