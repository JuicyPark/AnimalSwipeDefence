using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class Enemy : MonoBehaviour
    {
        public int health;
        public float speed;

        void FixedUpdate()
        {
            Move();
        }

        void Move() => transform.Translate(0, 0, speed * Time.deltaTime);

        public void Damage(int damage)
        {
            health -= damage;
            HealthCheck();
        }

        void HealthCheck()
        {
            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
