using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Burrel : BaseSceneObject, IDamageable
    {
        [SerializeField]
        private float health = 50f;

        [SerializeField]
        private Boom boom;

        public bool isAlive { get { return health > 0; } }

        public float CurentHealth { get { return health; } }

        public void ApplyDamage(float damage)
        {
            if (!isAlive) return;
            health -= damage;

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
            Collider.enabled = false;
            ExplosionDamage(gameObject.transform.position, 10);
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject, 3f);
        }

        private void ExplosionDamage(Vector3 center, float radius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                Debug.Log(hitColliders[i].name);
                if (hitColliders[i].GetComponent<Rigidbody>() != null)
                {
                    hitColliders[i].GetComponent<Rigidbody>().AddExplosionForce(10000, gameObject.transform.position, 10);
                }
                i++;
            }
        }
    }
}
