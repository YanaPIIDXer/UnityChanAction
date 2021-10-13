using System.Collections;
using System.Collections.Generic;
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
    }

    /// <summary>
    /// エネミークラス
    /// </summary>
    [RequireComponent(typeof(EnemyMove))]
    [RequireComponent(typeof(EnemyAnimation))]
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

        void Awake()
        {
            Move = GetComponent<EnemyMove>();
            Animation = GetComponent<EnemyAnimation>();
        }
    }
}
