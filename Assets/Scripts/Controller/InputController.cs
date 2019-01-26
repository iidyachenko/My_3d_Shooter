using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class InputController : MonoBehaviour
    {
        private float changeIndex=0;

        void Update()
        {
            if (Input.GetButtonDown("SwitchFlashlight"))
                Main.Instance.FlashlightController.SwitchFlashlight();

            if (Input.GetButtonDown("Action") && Main.Instance.PlayerController.hit.collider != null)
                Main.Instance.PlayerController.Get_Object(Main.Instance.PlayerController.hit);

            if (Input.GetButtonDown("ChangeWeapon"))
                Main.Instance.WeaponsController.ChangeWeapon();

            if (Input.GetButton("Fire1"))
                Main.Instance.WeaponsController.Fire();

            // Смена оружия через колесико мыши
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                Main.Instance.WeaponsController.ChangeWeapon(System.Convert.ToInt32(Input.GetAxis("Mouse ScrollWheel")*10));
            }

            //Перезарядка по клавише 'R'
            if (Input.GetButtonDown("Reload"))
                Main.Instance.WeaponsController.Reload();

            //Управление напарниками
            if (Input.GetButtonDown("TeammateCommand"))
                Main.Instance.TeammatesController.MoveCommand();
        }
    }
}

