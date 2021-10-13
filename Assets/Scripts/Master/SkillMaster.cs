using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    /// <summary>
    /// スキルマスタ
    /// </summary>
    public class SkillMaster
    {
        /// <summary>
        /// バイナリのパス
        /// </summary>
        private static readonly string BinaryPath = "Master/Skill";

        /// <summary>
        /// スキルデータを格納するDictionary
        /// </summary>
        private Dictionary<int, SkillData> dataDic = new Dictionary<int, SkillData>();

        /// <summary>
        /// 取得
        /// </summary>
        /// <param name="Id">スキルＩＤ</param>
        /// <returns>スキルデータ</returns>
        public static SkillData Get(int id)
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
            SkillData[] datas = SkillData.SerializeAll(binary);
            foreach (var data in datas)
            {
                instance.dataDic.Add(data.Id, data);
            }
        }

        #region Singleton
        private SkillMaster() { }
        private static SkillMaster instance = new SkillMaster();
        #endregion
    }
}
