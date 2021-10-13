using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

namespace Character.Player
{
    /// <summary>
    /// プレイヤーのアニメーションクラス
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        /// <summary>
        /// Animator
        /// </summary>
        private Animator animator = null;

        /// <summary>
        /// IPlayerControlインタフェースの注入
        /// </summary>
        /// <param name="playerControl">IPlayerControlインタフェース</param>
        [Inject]
        public void InjectPlayerControl(IPlayerControl playerControl)
        {
            playerControl.Move.Select(v => v.sqrMagnitude > 0.0f).Subscribe(bIsMove => animator.SetBool("IsMoving", bIsMove)).AddTo(gameObject);
        }

        /// <summary>
        /// スキルモーション再生
        /// </summary>
        /// <param name="motionName">モーション名</param>
        public void PlaySkilMotion(string motionName)
        {
            animator.Play(motionName, 0);
        }

        /// <summary>
        /// ニュートラルモーション再生
        /// </summary>
        public void PlayNutralMotion()
        {
            animator.Play("Nutral", 0);
        }

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        #region 導入したAssetにイベントが仕込まれているようで、それを握り潰すための定義
        public void SendEvent() { }
        #endregion
    }
}
