using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Player.State;

namespace Character.Player
{
    /// <summary>
    /// プレイヤーステート制御
    /// </summary>
    public class PlayerStateControl : MonoBehaviour
    {
        /// <summary>
        /// 現在のState
        /// </summary>
        private PlayerState currentState = null;

        /// <summary>
        /// Stateを設定
        /// </summary>
        /// <param name="nextState">次のState</param>
        public void SetNextState(PlayerState nextState)
        {
            if (currentState != null)
            {
                currentState.Terminate();
            }
            currentState = nextState;
            currentState.Begin();
        }

        void Awake()
        {
            SetNextState(new PlayerStateNutral(GetComponent<IPlayerFacade>()));
        }

        void Update()
        {
            currentState.Update();
        }
    }
}
