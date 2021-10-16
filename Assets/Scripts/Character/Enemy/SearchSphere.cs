using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Player;

namespace Character.Enemy
{
    /// <summary>
    /// 索敵用Sphere
    /// </summary>
    [RequireComponent(typeof(SphereCollider))]
    public class SearchSphere : MonoBehaviour
    {
        void Awake()
        {
            var collider = GetComponent<SphereCollider>();
            collider.isTrigger = true;
        }

        void OnTriggerEnter(Collider collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();
            if (player == null) { return; }

            Debug.Log("Player Searched!");
        }
    }
}
