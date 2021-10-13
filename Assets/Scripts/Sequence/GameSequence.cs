using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Master;

namespace Sequence
{
    /// <summary>
    /// ゲームシーケンス
    /// </summary>
    public class GameSequence : MonoBehaviour
    {
        void Awake()
        {
            LoadMasterData();
        }

        /// <summary>
        /// マスタデータの読み込み
        /// </summary>
        private void LoadMasterData()
        {
            SkillMaster.Load();
        }
    }
}
