using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

namespace Character.Player
{
    /// <summary>
    /// プレイヤー移動Component
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMove : MonoBehaviour
    {
        /// <summary>
        /// Rigidbody
        /// </summary>
        private Rigidbody rigidBody = null;

        /// <summary>
        /// 移動ベクトル
        /// </summary>
        private Vector2 moveVector = Vector2.zero;

        /// <summary>
        /// 移動可能？
        /// </summary>
        /// <value></value>
        public bool IsMovable { get; set; } = true;

        /// <summary>
        /// IPlayerControlインタフェースの注入
        /// </summary>
        /// <param name="playerControl">IPlayerControlインタフェース</param>
        [Inject]
        public void InjectPlayerControl(IPlayerControl playerControl)
        {
            playerControl.Move.Subscribe(v => moveVector = v).AddTo(gameObject);
        }

        void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (!IsMovable) { return; }
            rigidBody.velocity = new Vector3(moveVector.x, rigidBody.velocity.y, moveVector.y);
            transform.LookAt(transform.position + new Vector3(moveVector.x, 0.0f, moveVector.y));
        }
    }
}
