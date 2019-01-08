using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{ 
    public class FlashLightModel : MonoBehaviour {

        public event Action<bool> FlashlightStateChange;

        public bool isOn { get { return light.enabled; } }
        public int Energy { get; private set; }

        [SerializeField]
        private int EnergyStep;
        private Light light;

	    void Awake ()
        {
            light = GetComponent<Light>();
            Energy = 120;
            StartCoroutine(FlashlightEnergy());
        }

        public void On()
        {
            if (Energy >= 20)
            {
                light.enabled = true;
                if (FlashlightStateChange != null) FlashlightStateChange.Invoke(true);
            }
        }

        public void Off()
        {
            light.enabled = false;
            if (FlashlightStateChange != null) FlashlightStateChange.Invoke(false);
        }

        public IEnumerator FlashlightEnergy()
        {
            while (true)
            {
                if (light.enabled && Energy >= 0 && Energy <= 120)
                {
                    Energy-= EnergyStep;
                }
                else if(light.enabled == false && Energy <= 120 && Energy >= 0) 
                {
                    Energy += EnergyStep*2;
                }

                if (Energy <= 0) Off();

                yield return new WaitForSeconds(5);
            }
        }
    }
}
