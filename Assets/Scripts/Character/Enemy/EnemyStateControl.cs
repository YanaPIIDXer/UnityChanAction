﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Enemy.State;
using Master;

namespace Character.Enemy
{
    /// <summary>
    /// ステート制御
    /// </summary>
    public class EnemyStateControl : MonoBehaviour
    {
        /// <summary>
        /// 現在のステート
        /// </summary>
        private EnemyState currentState = null;

        /// <summary>
        /// 次のステートを設定
        /// </summary>
        /// <param name="nextState">次のステート</param>
        public void SetNextState(EnemyState nextState)
        {
            if (currentState != null)
            {
                currentState.Terminate();
            }
            currentState = nextState;
            currentState.Begin();
        }

        /// <summary>
        /// ダメージを受けた
        /// </summary>
        /// <param name="collisionData">コリジョンデータ</param>
        public void OnDamaged(CollisionData collisionData)
        {
        }

        void Awake()
        {
            SetNextState(new EnemyStateNutral(GetComponent<IEnemy>()));
        }

        void Update()
        {
            currentState.Update();
        }
    }
}
