using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Character.Enemy
{
    /// <summary>
    /// エネミーイベントを受信する側が購読するイベントObservableの定義
    /// </summary>
    public interface IEenmyEventObservable
    {
    }

    /// <summary>
    /// エネミーが保持するイベントObserverの定義
    /// </summary>
    public interface IEnemyEventObserver
    {
    }

    /// <summary>
    /// エネミーイベント
    /// </summary>
    public class EnemyEvent : MonoBehaviour, IEnemyEventObserver, IEenmyEventObservable
    {
    }
}
