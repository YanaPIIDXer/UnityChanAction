﻿using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;
using Zenject;
using UniRx;

namespace Character.Player
{
    /// <summary>
    /// プレイヤーの各Componentにアクセスするためのインタフェース
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// 移動Component
        /// </summary>
        PlayerMove Move { get; }

        /// <summary>
        /// アニメーションComponent
        /// </summary>
        PlayerAnimation Animation { get; }

        /// <summary>
        /// ステート制御
        /// </summary>
        PlayerStateControl State { get; }

        /// <summary>
        /// スキル
        /// </summary>
        PlayerSkill Skill { get; }

        /// <summary>
        /// コリジョン生成
        /// </summary>
        CollisionSpawner CollisionSpawn { get; }
    }

    /// <summary>
    /// プレイヤークラス
    /// </summary>
    [RequireComponent(typeof(PlayerMove))]
    [RequireComponent(typeof(PlayerAnimation))]
    [RequireComponent(typeof(PlayerStateControl))]
    [RequireComponent(typeof(PlayerSkill))]
    [RequireComponent(typeof(CollisionSpawner))]
    public class Player : MonoBehaviour, ICharacter, IPlayer
    {
        /// <summary>
        /// 移動Component
        /// </summary>
        public PlayerMove Move { get; private set; }

        /// <summary>
        /// アニメーションComponent
        /// </summary>
        /// <returns></returns>
        public PlayerAnimation Animation { get; private set; }

        /// <summary>
        /// ステート制御
        /// </summary>
        public PlayerStateControl State { get; private set; }

        /// <summary>
        /// スキル
        /// </summary>
        public PlayerSkill Skill { get; private set; }

        /// <summary>
        /// コリジョン生成
        /// </summary>
        public CollisionSpawner CollisionSpawn { get; private set; }

        void Awake()
        {
            Move = GetComponent<PlayerMove>();
            Animation = GetComponent<PlayerAnimation>();
            State = GetComponent<PlayerStateControl>();
            Skill = GetComponent<PlayerSkill>();
            CollisionSpawn = GetComponent<CollisionSpawner>();
        }

        /// <summary>
        /// マップ読み込みインタフェースの注入
        /// </summary>
        /// <param name="mapLoad">マップ読み込みインタフェース</param>
        [Inject]
        public void InjectMapLoad(IMapLoad mapLoad)
        {
            mapLoad.OnLoad.Subscribe(data =>
            {
                transform.position = new Vector3(data.StartX, data.StartY, data.StartZ);
                transform.eulerAngles = new Vector3(0.0f, data.StartRotation, 0.0f);
            }).AddTo(gameObject);
        }

    }
}
