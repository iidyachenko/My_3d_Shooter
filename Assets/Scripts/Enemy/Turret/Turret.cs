using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Turret : BaseSceneObject, IDamageable
    {
        [SerializeField] //броня для поглощения части урона
        private float armor = 0f;

        [SerializeField]
        private Boom boom;

        private Turret_main turret_main;
        public bool isAlive { get { return turret_main.Health > 0; } }

        public float CurentHealth { get { return turret_main.Health; } }

        private void Start()
        {
            turret_main = transform.parent.GetComponent<Turret_main>();
        }

        public void ApplyDamage(float damage)
        {
            if (!isAlive) return;
            turret_main.Health -= (damage / armor);
            //Вместа цвета вставить частицы попадания
           // Color = Random.ColorHSV();

            if (!isAlive) Die();

        }

        public void ApplyDamage(float damage, Vector3 DamageDirection)
        {
            if (!isAlive) return;
            ApplyDamage(damage);
        }

        private void Die()
        {
            Collider.enabled = false;
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject, 1f);
        }
    }
}
