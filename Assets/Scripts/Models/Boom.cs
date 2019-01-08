using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class Boom : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, 4);
        }

    }
}