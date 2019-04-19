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

        void Move()
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        // TODO : 이동


        // TODO : 체력
    }
}
