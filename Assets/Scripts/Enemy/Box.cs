using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FPS
{
    public class Box : BaseSceneObject, IDamageable
    {
        [SerializeField]
        private float health = 100f;
        public bool isAlive { get { return health > 0; } }

        public float CurentHealth { get { return health; } }
 
        public void ApplyDamage(float damage)
        {
            if (!isAlive) return;
            health -= damage;
            Color = Random.ColorHSV();

            if (!isAlive) Die();

        }

        public void ApplyDamage(float damage, Vector3 DamageDirection)
        {
            if (!isAlive) return;
            ApplyDamage(damage);

            Rigidbody.AddForce(DamageDirection, ForceMode.Impulse);
        }

        private void Die()
        {
            Color = Color.red;
            Collider.enabled = false;
            Destroy(gameObject, 3f);
        }
    }
}

