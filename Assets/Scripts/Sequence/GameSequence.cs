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

        /// <summary>
        /// マスタデータの読み込み
        /// </summary>
        private void LoadMasterData()
        {
            SkillMaster.Load();
            MapMaster.Load();
        }
    }
}
