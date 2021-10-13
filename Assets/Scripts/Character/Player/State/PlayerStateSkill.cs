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
        /// 経過時間
        /// </summary>
        private float elapsedTime = 0.0f;

        /// <summary>
        /// リンクを受け付けたか？
        /// </summary>
        private bool bIsLinkAccepted = false;

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
            Player.Animation.PlaySkilMotion(data.MotionName);
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public override void Terminate()
        {
            Player.Animation.PlayNutralMotion();
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= data.AcceptLinkTime && bIsLinkAccepted)
            {
                var nextData = SkillMaster.Get(data.LinkSkillId);
                Player.State.SetNextState(new PlayerStateSkill(Player, keyIndex, nextData));
            }
            else if (elapsedTime >= data.PlayTime)
            {
                Player.State.SetNextState(new PlayerStateNutral(Player));
            }
        }

        /// <summary>
        /// スキルを使用可能か？
        /// </summary>
        /// <param name="keyIndex"></param>
        /// <returns></returns>
        public override bool IsSkillUsable(int keyIndex)
        {
            if (keyIndex != this.keyIndex) { return false; }    // 違うスキルボタン
            if (elapsedTime > data.AcceptLinkTime) { return false; }        // リンク受付時間を過ぎている（硬直中）
            if (!SkillMaster.IsValidSkill(data.LinkSkillId)) { return false; }      // 有効なスキルではないのでリンクできない
            return true;
        }

        /// <summary>
        /// スキルを使用する
        /// </summary>
        /// <param name="keyIndex">キーインデックス</param>
        /// <param name="skillId">スキルＩＤ</param>
        public override void UseSkill(int keyIndex, int skillId)
        {
            // IsSkillUsableでリンク受付時間をチェックしているので、ここに来る＝リンクを受け付けるということ
            bIsLinkAccepted = true;
        }
    }
}
