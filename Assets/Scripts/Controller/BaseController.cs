using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseController : MonoBehaviour
    {
        public bool IsEnabled { get; private set; }

        public void On()
        {
            IsEnabled = true;
        }

        public void Off()
        {
            IsEnabled = false;
        }

    }

}
