using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class WeaponsController : BaseController
    {
        public BaseWeapon[] weapons { get; private set; }
        public event Action OnFireAction; //Вызывается при выстреле для обновления отображения боеприса
        public int curentWeapon { get; private set; }
        public int clip_bullet { get; private set; }

        private void Awake()
        {
            weapons = PlayerModel.localPlayer.weapons;
            for(int i =0 ; i < weapons.Length; i++)
            {
                weapons[i].IsVisible = i == curentWeapon;
            }
        }

        /// <summary>
        /// Смена оружия через клавиши
        /// </summary>
        public void ChangeWeapon()
        {
            weapons[curentWeapon].IsVisible = false;
            curentWeapon++;
            if (curentWeapon >= weapons.Length) curentWeapon = 0;
            weapons[curentWeapon].IsVisible = true;
        }

        public void ChangeWeapon(int input)
        {
            weapons[curentWeapon].IsVisible = false;
            curentWeapon+=input;
            if (curentWeapon >= weapons.Length) curentWeapon = 0;
            if (curentWeapon < 0) curentWeapon = weapons.Length -1;
            weapons[curentWeapon].IsVisible = true;
            OnFireAction.Invoke();
        }

        public void Fire()
        {
            if (weapons != null && weapons.Length > curentWeapon && weapons[curentWeapon] != null)
                weapons[curentWeapon].Fire();
            OnFireAction.Invoke();
        }

        public void Reload()
        {
            weapons[curentWeapon].Reload();
            OnFireAction.Invoke();
        }
    }
}

