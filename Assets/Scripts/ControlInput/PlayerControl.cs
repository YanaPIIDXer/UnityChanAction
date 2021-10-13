using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Player;
using UniRx;
using System;
using UniRx.Triggers;
using Zenject;
using Map;

namespace ControlInput
{
    /// <summary>
    /// プレイヤー制御
    /// </summary>
    public class PlayerControl : MonoBehaviour, IPlayerControl
    {
        /// <summary>
        /// 移動
        /// </summary>
        public IObservable<Vector2> Move => onUpdate.Select(_ => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized);

        /// <summary>
        /// スキル
        /// </summary>
        public IObservable<int> Skill => onUpdate.Select(_ =>
        {
            if (Input.GetKeyDown(KeyCode.Z)) { return 0; }
            if (Input.GetKeyDown(KeyCode.X)) { return 1; }
            if (Input.GetKeyDown(KeyCode.C)) { return 2; }
            return -1;
        }).Where(index => index != -1);

        /// <summary>
        /// 有効か？
        /// </summary>
        private bool bIsEnable = true;

        /// <summary>
        /// マップ読み込みインタフェースの注入
        /// </summary>
        /// <param name="mapLoad">マップ読み込みインタフェース</param>
        [Inject]
        public void InjectMapLoad(IMapLoad mapLoad)
        {
            mapLoad.BeginLoad.Subscribe(_ => bIsEnable = false).AddTo(gameObject);
            mapLoad.OnLoad.Subscribe(_ => bIsEnable = true).AddTo(gameObject);
        }

        /// <summary>
        /// UpdateAsObservableをラップするObservable
        /// プレイヤーを操作したくないタイミングでの入力を抑制するためのもの
        /// </summary>
        private IObservable<Unit> onUpdate => this.UpdateAsObservable().Where(_ => bIsEnable);
    }
}
