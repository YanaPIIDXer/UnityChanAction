using System.Collections;
using System.Collections.Generic;
using Character.Enemy.State;
using Collision;
using Master;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;

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
    [RequireComponent(typeof(EnemyDamageReaction))]
    [RequireComponent(typeof(ZenAutoInjecter))]
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
            Enemy prefab = Resources.Load<Enemy>(PrefabRootPath + data.PrefabName);
            Debug.Assert(prefab != null, "EnemyPrefab:" + data.PrefabName + " is Invalid.");

            var enemy = Instantiate<Enemy>(prefab, position, Quaternion.identity);
            enemy.hp = data.Hp;
            enemy.MaxHp = data.Hp;
            enemy.Name = data.CharacterName;

            var searchObj = new GameObject("SearchSphere");
            var searchSphere = searchObj.AddComponent<SearchSphere>();
            searchSphere.Setup(enemy, data.SearchRadius);
            searchObj.transform.parent = enemy.transform;
            searchObj.transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// HP
        /// </summary>
        public int Hp
        {
            get { return hp; }
            private set
            {
                hp = Mathf.Max(value, 0);
            }
        }
        private int hp = 1;

        /// <summary>
        /// 最大HP
        /// </summary>
        public int MaxHp { get; private set; }

        /// <summary>
        /// 名前
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }

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
        /// ダメージリアクション
        /// </summary>
        private EnemyDamageReaction damageReaction = null;

        /// <summary>
        /// 座標
        /// </summary>
        public Vector3 Position => transform.position;

        /// <summary>
        /// 回転
        /// </summary>
        public Quaternion Rotation => transform.rotation;

        /// <summary>
        /// イベントObserver
        /// </summary>
        [Inject]
        private IEnemyEventObserver eventObserver = null;

        void Awake()
        {
            Move = GetComponent<EnemyMove>();
            Animation = GetComponent<EnemyAnimation>();
            State = GetComponent<EnemyStateControl>();
            damageReaction = GetComponent<EnemyDamageReaction>();
        }

        /// <summary>
        /// ダメージを受けた
        /// </summary>
        /// <param name="collisionData">コリジョンデータ</param>
        /// <param name="blowVector">「吹き飛び」の場合の吹き飛びベクトル</param>
        public void OnDamaged(CollisionData collisionData, Vector3 blowVector)
        {
            Hp -= collisionData.Power;
            damageReaction.OnDamaged(collisionData, blowVector, (Hp == 0));
        }
    }
}
