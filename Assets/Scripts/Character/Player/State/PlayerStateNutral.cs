using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Player.State
{
    /// <summary>
    /// プレイヤーステート：通常
    /// </summary>
    public class PlayerStateNutral : PlayerState
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="playerFacade">各Componentへのアクセス用インタフェース</param>
        public PlayerStateNutral(IPlayerFacade playerFacade)
            : base(playerFacade)
        {
        }
    }
}
