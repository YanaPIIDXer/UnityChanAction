using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

namespace Character.Player
{
    /// <summary>
    /// スキルステート
    /// </summary>
    public class PlayerSkill : MonoBehaviour
    {
        /// <summary>
        /// インデックスに対応したスキルＩＤ
        /// </summary>
        private int[] skillIds = new int[3] { 1, 4, 5 };

        /// <summary>
        /// IPlayerControlインタフェースの注入
        /// </summary>
        /// <param name="playerControl">IPlayerControlインタフェース</param>
        [Inject]
        public void InjectPlayerControl(IPlayerControl playerControl)
        {
            playerControl.Skill.Subscribe(index =>
            {
                Debug.Log("SkillID:" + skillIds[index]);
            }).AddTo(gameObject);
        }
    }
}
