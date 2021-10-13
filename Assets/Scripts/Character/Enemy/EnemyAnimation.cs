using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy
{
    /// <summary>
    /// アニメーションComponent
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimation : MonoBehaviour
    {
        /// <summary>
        /// Animator
        /// </summary>
        private Animator animator = null;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// ニュートラルステート再生中か？
        /// </summary>
        /// <returns></returns>
        public bool IsNutralState => (animator.GetCurrentAnimatorStateInfo(0).IsName("Nutral") || animator.GetCurrentAnimatorStateInfo(0).IsName("Move"));

        /// <summary>
        /// ダメージモーション再生
        /// </summary>
        public void PlayDamageMotion()
        {
            animator.Play("Sword1h_Hit_Head_Front", 0);
        }

        /// <summary>
        /// 吹っ飛びモーション再生
        /// </summary>
        public void PlayBlowMotion()
        {
            animator.Play("Sword1h_Knockdown_Front", 0);
        }
    }
}
