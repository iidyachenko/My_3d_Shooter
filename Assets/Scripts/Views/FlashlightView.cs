using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class FlashlightView : MonoBehaviour
    {
        private FlashLightModel model;
        private Image image;

        private void Awake()
        {
            model = FindObjectOfType<FlashLightModel>();
            image = GetComponent<Image>();
            model.FlashlightStateChange += onFlashlightStateChanges;
            onFlashlightStateChanges(false);
        }

        private void Update()
        {
            image.fillAmount = model.Energy / 100f;
        }

        private void onFlashlightStateChanges(bool obj)
        {
            gameObject.SetActive(obj);
        }

        private void OnDestroy()
        {
            model.FlashlightStateChange -= onFlashlightStateChanges;
        }
    }
}
