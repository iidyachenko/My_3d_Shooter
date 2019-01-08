using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Main : MonoBehaviour
    {
        public static Main Instance { get; private set;}
        public FlashlightController FlashlightController { get; private set; }
        public InputController InputController { get; private set; }
        public PlayerController PlayerController { get; private set; }
        public WeaponsController WeaponsController { get; private set; }

        private void Awake()
        {
            if (Instance) DestroyImmediate(gameObject);
            else Instance = this;

            FlashlightController = gameObject.AddComponent<FlashlightController>();
            InputController = gameObject.AddComponent<InputController>();
            WeaponsController = gameObject.AddComponent<WeaponsController>();
            PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        private void Start()
        {
           
        }

    }
}

