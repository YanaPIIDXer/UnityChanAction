using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    /// <summary>
    /// キャラクタインタフェース
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// 座標
        /// </summary>
        Vector3 Position { get; }

        /// <summary>
        /// 回転
        /// </summary>
        Quaternion Rotation { get; }
    }
}
