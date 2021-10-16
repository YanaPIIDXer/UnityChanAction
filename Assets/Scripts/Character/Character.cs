using System.Collections;
using System.Collections.Generic;
using Master;
using UnityEngine;

namespace Character
{
    /// <summary>
    /// キャラクタインタフェース
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// HP
        /// </summary>
        /// <value></value>
        int Hp { get; }

        /// <summary>
        /// 最大HP
        /// </summary>
        int MaxHp { get; }

        /// <summary>
        /// 名前
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 座標
        /// </summary>
        Vector3 Position { get; }

        /// <summary>
        /// 回転
        /// </summary>
        Quaternion Rotation { get; }

        /// <summary>
        /// ダメージを受けた
        /// </summary>
        /// <param name="collisionData">コリジョンデータ</param>
        /// <param name="blowVector">「吹き飛び」の場合の吹き飛びベクトル</param>
        void OnDamaged(CollisionData collisionData, Vector3 blowVector);
    }
}
