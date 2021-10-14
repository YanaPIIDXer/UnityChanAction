using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using Map;

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
        /// ステート管理
        /// </summary>
        private PlayerStateControl stateControl = null;

        /// <summary>
        /// 移動ベクトル
        /// </summary>
        private Vector2 moveVector = Vector2.zero;

        /// <summary>
        /// 停止中か？
        /// </summary>
        private bool bIsFreeze = false;

        /// <summary>
        /// 移動速度
        /// </summary>
        private static readonly float moveSpeed = 1.5f;

        /// <summary>
        /// IPlayerControlインタフェースの注入
        /// </summary>
        /// <param name="playerControl">IPlayerControlインタフェース</param>
        [Inject]
        public void InjectPlayerControl(IPlayerControl playerControl)
        {
            playerControl.Move.Subscribe(v => moveVector = v).AddTo(gameObject);
        }

        /// <summary>
        /// マップ読み込みインタフェースの注入
        /// </summary>
        /// <param name="mapLoad">マップ読み込みインタフェース</param>
        [Inject]
        public void InjectMapLoad(IMapLoad mapLoad)
        {
            mapLoad.BeginLoad.Subscribe(_ => bIsFreeze = true).AddTo(gameObject);
            mapLoad.OnLoad.Subscribe(_ => bIsFreeze = false).AddTo(gameObject);
        }

        void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            stateControl = GetComponent<PlayerStateControl>();
        }

        void FixedUpdate()
        {
            if (!stateControl.IsMovable) { return; }

            if (bIsFreeze)
            {
                rigidBody.velocity = Vector3.zero;
                return;
            }

            rigidBody.velocity = new Vector3(moveVector.x, rigidBody.velocity.y, moveVector.y) * moveSpeed;
            transform.LookAt(transform.position + new Vector3(moveVector.x, 0.0f, moveVector.y));
        }
    }
}
