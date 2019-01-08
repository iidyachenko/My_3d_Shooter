using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS {
    public class ReloadView : MonoBehaviour {

        private Text text;
        private WeaponsController model;

        private void Start()
        {
            text = GetComponent<Text>();
            model = FindObjectOfType<WeaponsController>();
            //подписываем на обработку счетчика патронов
            Main.Instance.WeaponsController.OnFireAction += OnFireAction;
            OnFireAction();
        }

        private void OnFireAction()
        {
            text.text = model.weapons[model.curentWeapon].clip.ToString();
        }

        private void OnDestroy()
        {
            Main.Instance.WeaponsController.OnFireAction -= OnFireAction;
        }
    }
}
