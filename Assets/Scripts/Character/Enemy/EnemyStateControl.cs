using System.Collections;
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
        /// 動けるか？
        /// </summary>
        public bool IsMovable => currentState.IsMovable;

        /// <summary>
        /// PushStateメソッドの呼び出しで退避しているState
        /// </summary>
        private EnemyState pushedState = null;

        /// <summary>
        /// 次のステートを設定
        /// </summary>
        /// <param name="nextState">次のステート</param>
        public void SetNextState(EnemyState nextState)
        {
            if (currentState != null && !currentState.IsStateChangeable) { return; }

            if (currentState != null)
            {
                currentState.Terminate();
            }
            currentState = nextState;
            currentState.Begin();
        }

        /// <summary>
        /// ステートのプッシュ
        /// 現在のステートは一時退避され、
        /// PopStateメソッドの呼び出しによって戻る
        /// </summary>
        /// <param name="nextState"></param>
        public void PushState(EnemyState nextState)
        {
            if (!currentState.IsStateChangeable) { return; }

            if (pushedState == null)
            {
                pushedState = currentState;
            }

            currentState = nextState;
            currentState.Begin();
        }

        /// <summary>
        /// Pushステートで退避しておいたステートに戻す
        /// </summary>
        public void PopState()
        {
            if (pushedState == null) { return; }

            currentState = pushedState;
            pushedState = null;
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
