using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class SingleBurrieldFire : BaseWeapon
    {
        [SerializeField]
        private Transform firepoint;

        protected override void FireAction()
        {
            BaseAmmo bullet = Instantiate(bulletPrefub, firepoint.position, firepoint.rotation);
            bullet.Initialize(shotForce);
        }

    }
}