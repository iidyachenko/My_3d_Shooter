using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FPS
{
    public class Waypoint : MonoBehaviour
    {
        public float whaitTime = 1f;
        public UnityEvent OnReachEvent;
    }
}