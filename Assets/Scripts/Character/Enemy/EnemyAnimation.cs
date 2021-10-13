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
        /// ダメージモーション再生
        /// </summary>
        public void PlayDamageMotion()
        {
            animator.Play("Sword1h_Hit_Head_Front", 0);
        }
    }
}
