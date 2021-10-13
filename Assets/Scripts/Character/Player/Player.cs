using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Player
{
    /// <summary>
    /// プレイヤーの各Componentにアクセスするためのインタフェース
    /// </summary>
    public interface IPlayerFacade
    {
    }

    /// <summary>
    /// プレイヤークラス
    /// </summary>
    public class Player : MonoBehaviour, ICharacter, IPlayerFacade
    {
    }
}
