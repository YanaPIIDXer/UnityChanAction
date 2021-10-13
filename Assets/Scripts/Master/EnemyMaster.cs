using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    public class EnemyMaster
    {
        /// <summary>
        /// バイナリのパス
        /// </summary>
        private static readonly string BinaryPath = "Master/EnemyMaster";

        /// <summary>
        /// エネミーデータを格納するDictionary
        /// </summary>
        private Dictionary<int, EnemyData> dataDic = new Dictionary<int, EnemyData>();

        /// <summary>
        /// 取得
        /// </summary>
        /// <param name="id">エネミーＩＤ</param>
        /// <returns>スキルデータ</returns>
        public static EnemyData Get(int id)
        {
            if (instance.dataDic.ContainsKey(id)) { return instance.dataDic[id]; }
            return null;
        }

        /// <summary>
        /// 読み込み
        /// </summary>
        public static void Load()
        {
            instance.dataDic.Clear();

            var textAsset = Resources.Load<TextAsset>(BinaryPath);
            byte[] binary = textAsset.bytes;
            EnemyData[] datas = EnemyData.SerializeAll(binary);
            foreach (var data in datas)
            {
                instance.dataDic.Add(data.Id, data);
            }
        }

        #region Singleton
        private EnemyMaster() { }
        private static EnemyMaster instance = new EnemyMaster();
        #endregion

    }
}
