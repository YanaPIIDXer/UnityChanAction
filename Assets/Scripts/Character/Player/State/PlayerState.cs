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
        protected IPlayer Player { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="playerFacade">各Componentへのアクセス用インタフェース</param>
        public PlayerState(IPlayer playerFacade)
        {
            Player = playerFacade;
        }

        /// <summary>
        /// 移動可能か？
        /// </summary>
        public virtual bool IsMovable => false;

        /// <summary>
        /// スキルを使用可能か？
        /// </summary>
        /// <param name="keyIndex">キーのインデックス</param>
        /// <returns>使用可能ならtrueを返す</returns>
        public abstract bool IsSkillUsable(int keyIndex);

        /// <summary>
        /// スキルを使用する
        /// </summary>
        /// <param name="keyIndex">キーのインデックス</param>
        /// <param name="skillId">スキルＩＤ</param>
        public virtual void UseSkill(int keyIndex, int skillId) { }

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
