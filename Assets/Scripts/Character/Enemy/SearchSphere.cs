using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Player;

namespace Character.Enemy
{
    /// <summary>
    /// 索敵用Sphere
    /// </summary>
    [RequireComponent(typeof(SphereCollider))]
    public class SearchSphere : MonoBehaviour
    {
        /// <summary>
        /// エネミーComponentアクセス用インタフェース
        /// </summary>
        private IEnemy enemyComponents = null;

        /// <summary>
        /// セットアップ
        /// </summary>
        /// <param name="enemyComponents">エネミーComponentアクセス用インタフェース</param>
        /// <param name="radius">半径</param>
        public void Setup(IEnemy enemyComponents, float radius)
        {
            var collider = GetComponent<SphereCollider>();
            collider.isTrigger = true;
            collider.radius = radius;
            this.enemyComponents = enemyComponents;
        }

        void OnTriggerEnter(Collider collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();
            if (player == null) { return; }

            enemyComponents.AI.TargetPlayer = player;
            enemyComponents.AI.Execute();
        }
    }
}
