using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collision
{
    /// <summary>
    /// コリジョンヒット時の反応の種類
    /// </summary>
    public static class ReactionType
    {
        /// <summary>
        /// 何も無し
        /// </summary>
        public const byte None = 0;

        /// <summary>
        /// 吹っ飛び
        /// </summary>
        public const byte Blow = 1;

        /// <summary>
        /// 打ち上げ
        /// </summary>
        public const byte Lift = 2;
    }
}
