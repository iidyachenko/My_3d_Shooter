using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public interface IDamageable
    {
        float CurentHealth{get;}
        void ApplyDamage(float damage,Vector3 DamageDirection);
        void ApplyDamage(float damage);
    }

}
