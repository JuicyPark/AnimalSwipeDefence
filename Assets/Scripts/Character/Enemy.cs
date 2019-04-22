using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class Enemy : MonoBehaviour
    {
        float slowTime = 1.5f;
        bool slowing = false;

        [SerializeField] MeshRenderer _meshRenderer;
        [SerializeField] Material freezeMaterial;

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

        public void Damage(int damage, bool isSlow, float slowRate)
        {
            health -= damage;
            HealthCheck();
            if(!slowing)
                StartCoroutine(CDecreaseSpeed(slowRate));
        }

        void HealthCheck()
        {
            if (health <= 0)
                Destroy(gameObject);
        }

        IEnumerator CDecreaseSpeed(float slowRate)
        {
            slowing = true;
            Material originMaterial = _meshRenderer.material;
            _meshRenderer.material = freezeMaterial;
            float originSpeed = speed;
            speed *= slowRate;
            yield return new WaitForSeconds(slowTime);
            speed = originSpeed;
            _meshRenderer.material = originMaterial;
            slowing = false;
        }
    }
}
