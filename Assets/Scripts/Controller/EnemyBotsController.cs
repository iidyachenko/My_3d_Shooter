using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class EnemyBotsController : MonoBehaviour
    {
        private List<EnemyBot> botList = new List<EnemyBot>();
        private Transform targetTransform;

        private void Start()
        {
            targetTransform = PlayerModel.localPlayer.transform;

            foreach (var bot in FindObjectsOfType<EnemyBot>()) AddBot(bot);
        }

        public void AddBot(EnemyBot bot)
        {
            if (botList.Contains(bot)) return;
            botList.Add(bot);
            bot.SetTarget(targetTransform);
        }

        public void RemoveBot(EnemyBot bot)
        {
            if (!botList.Contains(bot)) return;
            botList.Remove(bot);
        }
    }
}
