using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy.State
{
    /// <summary>
    /// エネミーステート：何もしていない
    /// </summary>
    public class EnemyStateNutral : EnemyState
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enemy">各Componentへの参照用インタフェース</param>
        public EnemyStateNutral(IEnemy enemy)
            : base(enemy)
        {
        }
    }
}
