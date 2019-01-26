using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class BotSpawner : MonoBehaviour
    {
        public Waypoint[] Waypoints;
        public EnemyBot BotPrefab;

        private EnemyBot Instance;

        private void Update()
        {
            if (Instance) return;
            Instance = Instantiate(BotPrefab, transform.position, transform.rotation);
            Instance.Initialize(this);
        }

    }
}
