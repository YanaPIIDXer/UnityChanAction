using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Player.State
{
    /// <summary>
    /// プレイヤーステート基底クラス
    /// </summary>
    public abstract class PlayerState
    {
        /// <summary>
        /// 各Componentへのアクセス用インタフェース
        /// </summary>
        protected IPlayerFacade Player { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="playerFacade">各Componentへのアクセス用インタフェース</param>
        public PlayerState(IPlayerFacade playerFacade)
        {
            Player = playerFacade;
        }

        /// <summary>
        /// 開始処理
        /// </summary>
        public virtual void Begin() { }

        /// <summary>
        /// 更新
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// 終了処理
        /// </summary>
        public virtual void Terminate() { }
    }
}
