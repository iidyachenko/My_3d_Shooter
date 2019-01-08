using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseWeapon : BaseSceneObject
    {
        [SerializeField]
        protected BaseAmmo bulletPrefub;

        [SerializeField]
        protected float shotForce;

        [SerializeField]
        protected AudioClip reload_clip;

        public float reloadTime;
      
        public int clip;

        private int clip_base;


        [SerializeField]
        protected float Timeout;
        protected float lastShotTime;

        private void Start()
        {
            clip_base = clip;
        }

        public virtual void Fire()
        {
            if (Time.time - lastShotTime < Timeout) return;
            lastShotTime = Time.time;            
            if (clip == 0)
            {
                Reload();
                return;
            }
            clip--;
            FireAction();
        }

        public void Reload()
        {
            lastShotTime += reloadTime;
            clip = clip_base;
            AudioSource.PlayClipAtPoint(reload_clip, transform.position);
        }

        protected abstract void FireAction();
    }
}