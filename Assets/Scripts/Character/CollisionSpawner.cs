﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Master;

namespace Character
{
    /// <summary>
    /// コリジョン生成
    /// </summary>
    public class CollisionSpawner : MonoBehaviour
    {
        /// <summary>
        /// データリスト
        /// </summary>
        private List<CollisionData> dataList = new List<CollisionData>();

        /// <summary>
        /// 経過時間
        /// </summary>
        private float elapsedTime = 0.0f;

        /// <summary>
        /// スキル開始時に呼び出す
        /// </summary>
        /// <param name="skillId">スキルＩＤ</param>
        public void OnStartSkill(int skillId)
        {
            dataList = CollisionMaster.Collect(skillId);
            elapsedTime = 0.0f;
        }

        void Update()
        {
            if (dataList.Count == 0) { return; }

            elapsedTime += Time.deltaTime;

            for (int i = dataList.Count - 1; i >= 0; i--)
            {
                if (elapsedTime >= dataList[i].SpawnTime)
                {
                    Debug.Log("TODO:コリジョン生成処理");
                    dataList.RemoveAt(i);
                }
            }
        }
    }
}
