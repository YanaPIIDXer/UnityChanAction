using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Master;

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
        public PlayerStateNutral(IPlayer playerFacade)
            : base(playerFacade)
        {
        }

        /// <summary>
        /// 移動可能か？
        /// </summary>
        public override bool IsMovable => true;

        /// <summary>
        /// スキルを使用可能か？
        /// </summary>
        /// <param name="keyIndex">キーのインデックス</param>
        /// <returns>普通に使えるのでtrueしか返さない</returns>
        public override bool IsSkillUsable(int keyIndex)
        {
            return true;
        }

        /// <summary>
        /// スキルを使用する
        /// </summary>
        /// <param name="keyIndex">キーインデックス</param>
        /// <param name="skillId">スキルＩＤ</param>
        public override void UseSkill(int keyIndex, int skillId)
        {
            var skillData = SkillMaster.Get(skillId);
            Player.State.SetNextState(new PlayerStateSkill(Player, keyIndex, skillData));
        }
    }
}
