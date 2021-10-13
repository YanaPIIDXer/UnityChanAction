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
    }

    /// <summary>
    /// プレイヤークラス
    /// </summary>
    [RequireComponent(typeof(PlayerMove))]
    public class Player : MonoBehaviour, ICharacter, IPlayerFacade
    {
        /// <summary>
        /// 移動Component
        /// </summary>
        public PlayerMove Move { get; private set; }

        void Awake()
        {
            Move = GetComponent<PlayerMove>();
        }
    }
}
