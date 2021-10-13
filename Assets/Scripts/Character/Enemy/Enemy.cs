using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy
{
    /// <summary>
    /// 各Componentにアクセスするためのインタフェース
    /// </summary>
    public interface IEnemy
    {
    }

    /// <summary>
    /// エネミークラス
    /// </summary>
    public class Enemy : MonoBehaviour, ICharacter, IEnemy
    {
    }
}
