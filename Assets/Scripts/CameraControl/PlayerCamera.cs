using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControl
{
    /// <summary>
    /// プレイヤーカメラクラス
    /// </summary>
    public class PlayerCamera : MonoBehaviour
    {
        /// <summary>
        /// プレイヤーTransform
        /// TODO:PlayerをPrefabからInstantiateするような作りになる場合はまた別途考える
        /// </summary>
        [SerializeField]
        private Transform playerTransform = null;

        /// <summary>
        /// 視点の高さオフセット
        /// </summary>
        private static readonly float HeightOffset = 1.8f;

        /// <summary>
        /// プレイヤーからの距離
        /// </summary>
        private static readonly float distance = 2.5f;

        void Update()
        {
            var lookAt = playerTransform.position + Vector3.up * HeightOffset;
            transform.position = lookAt - Vector3.forward * distance;
            transform.LookAt(lookAt);
        }
    }
}
