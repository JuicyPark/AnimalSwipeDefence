using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class EnemyBoss : Enemy
    {
        protected override void HealthCheck()
        {
            if (health <= 0) EventManager.Instance.onBossClearInvoke();
            base.HealthCheck();
        }
    }
}