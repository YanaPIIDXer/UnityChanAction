using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy
{
    /// <summary>
    /// 敵の移動
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMove : MonoBehaviour
    {
        /// <summary>
        /// Rigidbody
        /// </summary>
        private Rigidbody rigidBody = null;

        /// <summary>
        /// 移動ベクトル
        /// </summary>
        public Vector2 MoveVector { set; private get; }

        /// <summary>
        /// 力
        /// </summary>
        private Vector3? force = null;

        /// <summary>
        /// 力を加える
        /// </summary>
        /// <param name="force">加える力</param>
        public void AddForce(Vector3 force)
        {
            this.force = force;
        }

        void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (force != null)
            {
                rigidBody.AddForce(force.Value, ForceMode.Force);
                force = null;
            }

            rigidBody.velocity = new Vector3(MoveVector.x, rigidBody.velocity.y, MoveVector.y);
            transform.LookAt(transform.position + new Vector3(MoveVector.x, 0.0f, MoveVector.y));
        }
    }
}
