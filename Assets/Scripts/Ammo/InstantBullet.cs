using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class InstantBullet : BaseAmmo
    {
        [SerializeField]
        private float lifetime = 4f;

        private float speed;

        public override void Initialize(float force)
        {
            speed = force;
            Destroy(gameObject, lifetime);
        }

        private void Start()
        {
            IDamageable d = GetComponentInParent<IDamageable>();
            if (d != null) d.ApplyDamage(damage, transform.forward * speed);
        }
    }
}
