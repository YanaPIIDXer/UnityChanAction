using System.Collections;
using System.Collections.Generic;
using Character;
using Master;
using UnityEngine;

namespace Collision
{
    /// <summary>
    /// 攻撃コリジョン
    /// </summary>
    [RequireComponent(typeof(SphereCollider))]
    public class AttackCollision : MonoBehaviour
    {
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="owner">発生源キャラ</param>
        /// <param name="data">コリジョンデータ</param>
        public static void Spawn(ICharacter owner, CollisionData data)
        {
            var obj = new GameObject("AttackCollision");
            obj.transform.position = owner.Position + (owner.Rotation * new Vector3(data.OffsetX, data.OffsetY, data.OffsetZ));
            var collision = obj.AddComponent<AttackCollision>();
            collision.lifeTime = data.LifeTime;
            collision.collider.radius = data.Radius;
            collision.data = data;
            collision.owner = owner;
        }

        /// <summary>
        /// 残り生存時間
        /// </summary>
        private float lifeTime = 1.0f;

        /// <summary>
        /// コライダ
        /// </summary>
        private new SphereCollider collider = null;

        /// <summary>
        /// データ
        /// </summary>
        private CollisionData data = null;

        /// <summary>
        /// 発生源
        /// </summary>
        private ICharacter owner = null;

        void Awake()
        {
            collider = GetComponent<SphereCollider>();
            collider.isTrigger = true;
        }

        void Update()
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0.0f)
            {
                Destroy(gameObject);
            }
        }

        void OnTriggerEnter(Collider collision)
        {
            var hitCharacter = collision.gameObject.GetComponent<ICharacter>();
            if (hitCharacter == null || hitCharacter == owner) { return; }
            hitCharacter.OnDamaged(data);
        }
    }
}
