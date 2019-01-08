using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Bullet : BaseAmmo
    {

        [SerializeField]
        LayerMask layerMask;
        [SerializeField]
        private float lifetime = 2f;

        private float speed;
        private bool isHitted;

        public override void Initialize(float force)
        {
            speed = force;
            Destroy(gameObject, lifetime);
        }

        private void FixedUpdate()
        {
            if (isHitted) return;
            var finalPos = transform.position + transform.forward * speed * Time.fixedDeltaTime;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, finalPos, out hit, layerMask))
            {
                isHitted = true;
                transform.position = hit.point;

                IDamageable d = hit.collider.GetComponent<IDamageable>();
                if (d != null) d.ApplyDamage(damage, transform.forward * speed);

                Destroy(gameObject, 0.4f);
            }
            else
            {
                transform.position = finalPos;
            }
        }
    }
}

