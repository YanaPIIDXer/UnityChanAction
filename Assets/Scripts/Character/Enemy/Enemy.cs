using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy
{
    /// <summary>
    /// 各Componentにアクセスするためのインタフェース
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// 移動Component
        /// </summary>
        EnemyMove Move { get; }

        /// <summary>
        /// アニメーションComponent
        /// </summary>
        EnemyAnimation Animation { get; }
    }

    /// <summary>
    /// エネミークラス
    /// </summary>
    [RequireComponent(typeof(EnemyMove))]
    [RequireComponent(typeof(EnemyAnimation))]
    public class Enemy : MonoBehaviour, ICharacter, IEnemy
    {
        /// <summary>
        /// 移動Component
        /// </summary>
        public EnemyMove Move { get; private set; }

        /// <summary>
        /// アニメーションComponent
        /// </summary>
        public EnemyAnimation Animation { get; private set; }

        void Awake()
        {
            Move = GetComponent<EnemyMove>();
            Animation = GetComponent<EnemyAnimation>();
        }
    }
}
