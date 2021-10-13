using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Player
{
    /// <summary>
    /// プレイヤーの各Componentにアクセスするためのインタフェース
    /// </summary>
    public interface IPlayerFacade
    {
        /// <summary>
        /// 移動Component
        /// </summary>
        PlayerMove Move { get; }

        /// <summary>
        /// アニメーションComponent
        /// </summary>
        PlayerAnimation Animation { get; }
    }

    /// <summary>
    /// プレイヤークラス
    /// </summary>
    [RequireComponent(typeof(PlayerMove))]
    [RequireComponent(typeof(PlayerAnimation))]
    public class Player : MonoBehaviour, ICharacter, IPlayerFacade
    {
        /// <summary>
        /// 移動Component
        /// </summary>
        public PlayerMove Move { get; private set; }

        /// <summary>
        /// アニメーションComponent
        /// </summary>
        /// <returns></returns>
        public PlayerAnimation Animation { get; private set; }

        void Awake()
        {
            Move = GetComponent<PlayerMove>();
            Animation = GetComponent<PlayerAnimation>();
        }
    }
}
