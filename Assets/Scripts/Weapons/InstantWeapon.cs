using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class InstantWeapon : BaseWeapon
    {
        private Ray firepoint;
        [SerializeField]
        private float distance;
        public RaycastHit hit;
        private Transform objectHit;
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        protected override void FireAction()
        {
            firepoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(firepoint, out hit, distance))
            {
                objectHit = hit.transform;
                BaseAmmo bulletHole = Instantiate(bulletPrefub, hit.point, Quaternion.Euler(0,90,0));
                bulletHole.transform.parent = objectHit;
                bulletHole.Initialize(shotForce);
                anim.SetBool("isFire", true);
                anim.SetBool("isFire", false);
            }
        }
    }

}
