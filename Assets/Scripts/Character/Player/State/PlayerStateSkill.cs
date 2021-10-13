using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Master;

namespace Character.Player.State
{
    /// <summary>
    /// プレイヤーステート：スキル
    /// </summary>
    public class PlayerStateSkill : PlayerState
    {
        /// <summary>
        /// キーインデックス
        /// リンクの際に同じキーが押されたかどうかを判定するために使用
        /// </summary>
        private int keyIndex = 0;

        /// <summary>
        /// スキルデータ
        /// </summary>
        private SkillData data = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="playerFacade">各Componentへのアクセス用インタフェース</param>
        /// <param name="keyIndex">キーインデックス</param>
        /// <param name="data">スキルデータ</param>
        public PlayerStateSkill(IPlayerFacade playerFacade, int keyIndex, SkillData data)
            : base(playerFacade)
        {
            this.keyIndex = keyIndex;
            this.data = data;
        }

        /// <summary>
        /// 開始処理
        /// </summary>
        public override void Begin()
        {
            Debug.Log("Use Skill ID:" + data.Id);
        }

        /// <summary>
        /// スキルを使用可能か？
        /// </summary>
        /// <param name="keyIndex"></param>
        /// <returns></returns>
        public override bool IsSkillUsable(int keyIndex)
        {
            return (keyIndex == this.keyIndex);
        }
    }
}
