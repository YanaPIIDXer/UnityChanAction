using System.Collections;
using System.Collections.Generic;
using Collision;
using Master;
using UnityEngine;

namespace Character.Enemy
{
    /// <summary>
    /// 各Componentにアクセスするためのインタフェース
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// 移動Component
        /// </summary>
        EnemyMove Move { get; }

        /// <summary>
        /// アニメーションComponent
        /// </summary>
        EnemyAnimation Animation { get; }

        /// <summary>
        /// ステート制御
        /// </summary>
        EnemyStateControl State { get; }
    }

    /// <summary>
    /// エネミークラス
    /// </summary>
    [RequireComponent(typeof(EnemyMove))]
    [RequireComponent(typeof(EnemyAnimation))]
    [RequireComponent(typeof(EnemyStateControl))]
    public class Enemy : MonoBehaviour, ICharacter, IEnemy
    {
        /// <summary>
        /// Prefabのルートパス
        /// </summary>
        private static readonly string PrefabRootPath = "Prefabs/Enemy/";

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="data">マスタデータ</param>
        /// <param name="position">座標</param>
        public static void Spawn(EnemyData data, Vector3 position)
        {
            // TODO:PrefabManagerみたいなのを作って管理できるようにする
            GameObject prefab = Resources.Load<GameObject>(PrefabRootPath + data.PrefabName);
            Debug.Assert(prefab != null, "EnemyPrefab:" + data.PrefabName + " is Invalid.");

            Instantiate(prefab, position, Quaternion.identity);
        }

        /// <summary>
        /// 移動Component
        /// </summary>
        public EnemyMove Move { get; private set; }

        /// <summary>
        /// アニメーションComponent
        /// </summary>
        public EnemyAnimation Animation { get; private set; }

        /// <summary>
        /// ステート制御
        /// </summary>
        public EnemyStateControl State { get; private set; }

        /// <summary>
        /// 座標
        /// </summary>
        public Vector3 Position => transform.position;

        /// <summary>
        /// 回転
        /// </summary>
        public Quaternion Rotation => transform.rotation;

        void Awake()
        {
            Move = GetComponent<EnemyMove>();
            Animation = GetComponent<EnemyAnimation>();
            State = GetComponent<EnemyStateControl>();
        }

        /// <summary>
        /// ダメージを受けた
        /// </summary>
        /// <param name="collisionData">コリジョンデータ</param>
        public void OnDamaged(CollisionData collisionData)
        {
            if (collisionData.ReactionType == ReactionType.None)
            {
                Animation.PlayDamageMotion();
            }
            else
            {
                State.OnDamaged(collisionData);
            }
        }
    }
}
