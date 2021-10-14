using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Master;
using Map;
using Zenject;

namespace Sequence
{
    /// <summary>
    /// ゲームシーケンス
    /// </summary>
    public class GameSequence : MonoBehaviour
    {
        /// <summary>
        /// マップロードインタフェース
        /// </summary>
        [Inject]
        private IMapLoad mapLoad = null;

        void Awake()
        {
            LoadMasterData();
            mapLoad.Load(1).Forget();
        }

        void Start()
        {
            // 試しにエネミーを置いてみる
            Character.Enemy.Enemy.Spawn(EnemyMaster.Get(1), new Vector3(0.0f, 0.0f, 5.0f));
        }

        /// <summary>
        /// マスタデータの読み込み
        /// </summary>
        private void LoadMasterData()
        {
            SkillMaster.Load();
            MapMaster.Load();
            EnemyMaster.Load();
            CollisionMaster.Load();
        }
    }
}
