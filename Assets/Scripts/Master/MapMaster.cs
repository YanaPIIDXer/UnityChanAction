using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    /// <summary>
    /// マップマスタ
    /// </summary>
    public class MapMaster
    {
        /// <summary>
        /// バイナリのパス
        /// </summary>
        private static readonly string BinaryPath = "Master/MapMaster";

        /// <summary>
        /// IDをキーにデータを格納するDictionary
        /// </summary>
        private Dictionary<int, MapData> dataDic = new Dictionary<int, MapData>();

        /// <summary>
        /// 取得
        /// </summary>
        /// <param name="id">マップＩＤ</param>
        /// <returns>マップデータ</returns>
        public static MapData Get(int id)
        {
            if (!instance.dataDic.ContainsKey(id)) { return null; }
            return instance.dataDic[id];
        }

        /// <summary>
        /// 読み込み
        /// </summary>
        public static void Load()
        {
            instance.dataDic.Clear();

            var textAsset = Resources.Load<TextAsset>(BinaryPath);
            byte[] binary = textAsset.bytes;
            MapData[] datas = MapData.SerializeAll(binary);
            foreach (var data in datas)
            {
                instance.dataDic.Add(data.Id, data);
            }
        }

        #region Singleton
        private MapMaster() { }
        private static MapMaster instance = new MapMaster();
        #endregion
    }
}
