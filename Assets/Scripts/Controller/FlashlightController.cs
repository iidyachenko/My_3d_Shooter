using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashlightController : BaseController
    {
        private FlashLightModel model;

        private void Awake()
        {
            model = FindObjectOfType<FlashLightModel>();
            model.Off();           
        }

        public void SwitchFlashlight()
        {
            if (model.isOn)

                 model.Off();
            else model.On();
        }

    }

}

