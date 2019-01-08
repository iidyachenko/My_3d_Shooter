using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class PlayerModel : MonoBehaviour
    {
        public static PlayerModel localPlayer { get; private set; }
        public BaseWeapon[] weapons;

        private void Awake()
        {
            if (localPlayer) DestroyImmediate(gameObject);
            else localPlayer = this;
        }
    }
}

