using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class MultiBurrieldFire : BaseWeapon
    {
        [SerializeField]
        private Transform[] firepoints;
        private int currentFirepoint;

        protected override void FireAction()
        {
            BaseAmmo bullet = Instantiate(bulletPrefub, firepoints[currentFirepoint].position, firepoints[currentFirepoint].rotation);
            bullet.Initialize(shotForce);
            currentFirepoint++;
            if (currentFirepoint >= firepoints.Length) currentFirepoint = 0;
        }


    }
}