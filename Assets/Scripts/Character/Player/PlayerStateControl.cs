using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Player.State;
using Master;

namespace Character.Player
{
    /// <summary>
    /// プレイヤーステート制御
    /// </summary>
    public class PlayerStateControl : MonoBehaviour
    {
        /// <summary>
        /// 現在のState
        /// </summary>
        private PlayerState currentState = null;

        /// <summary>
        /// Stateを設定
        /// </summary>
        /// <param name="nextState">次のState</param>
        public void SetNextState(PlayerState nextState)
        {
            if (currentState != null)
            {
                currentState.Terminate();
            }
            currentState = nextState;
            currentState.Begin();
        }

        /// <summary>
        /// スキル使用
        /// </summary>
        /// <param name="keyIndex">キーのインデックス</param>
        /// <param name="skillId">スキルＩＤ</param>
        public void UseSkill(int keyIndex, int skillId)
        {
            if (!SkillMaster.IsValidSkill(skillId)) { return; }
            if (!currentState.IsSkillUsable(keyIndex)) { return; }
            currentState.UseSkill(keyIndex, skillId);
        }

        void Awake()
        {
            SetNextState(new PlayerStateNutral(GetComponent<IPlayer>()));
        }

        void Update()
        {
            currentState.Update();
        }
    }
}
