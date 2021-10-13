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

        void Awake()
        {
            animator = GetComponent<Animator>();
        }
    }
}
