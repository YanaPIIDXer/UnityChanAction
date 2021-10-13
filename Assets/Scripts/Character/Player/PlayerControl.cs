using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Character.Player
{
    /// <summary>
    /// プレイヤー制御インタフェース
    /// </summary>
    public interface IPlayerControl
    {
        /// <summary>
        /// 移動
        /// </summary>
        IObservable<Vector2> Move { get; }

        /// <summary>
        /// スキル
        /// </summary>
        IObservable<int> Skill { get; }
    }
}
