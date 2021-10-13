using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    public class CollisionMaster
    {
        /// <summary>
        /// バイナリのパス
        /// </summary>
        private static readonly string BinaryPath = "Master/CollisionMaster";

        /// <summary>
        /// データリスト
        /// </summary>
        private CollisionData[] datas = null;

        /// <summary>
        /// 指定したスキルＩＤのものを列挙
        /// </summary>
        /// <param name="skillId">スキルＩＤ</param>
        /// <returns>データリスト</returns>
        public static List<CollisionData> Collect(int skillId)
        {
            List<CollisionData> list = new List<CollisionData>();
            foreach (var data in instance.datas)
            {
                if (data.SkillId == skillId)
                {
                    list.Add(data);
                }
            }
            return list;
        }

        /// <summary>
        /// 読み込み
        /// </summary>
        public static void Load()
        {
            var textAsset = Resources.Load<TextAsset>(BinaryPath);
            byte[] binary = textAsset.bytes;
            instance.datas = CollisionData.SerializeAll(binary);
        }

        #region Singleton
        private CollisionMaster() { }
        private static CollisionMaster instance = new CollisionMaster();
        #endregion

    }
}
