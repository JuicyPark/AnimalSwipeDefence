using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
    public class Enemy : MonoBehaviour
    {
        float slowTime = 1.5f;
        bool slowing = false;

        [SerializeField] MeshRenderer _meshRenderer;
        [SerializeField] Material freezeMaterial;
        [SerializeField] Image _healthBar;

        public float maxHealth;
        public float health;
        public float speed;

        void FixedUpdate()
        {
            Move();
        }

        void Move() => transform.Translate(0, 0, speed * Time.deltaTime);

        public void Damage(float damage)
        {
            health -= damage;
            HealthCheck();
        }

        public void Damage(float damage, bool isSlow, float slowRate)
        {
            health -= damage;
            HealthCheck();
            if(!slowing)
                StartCoroutine(CDecreaseSpeed(slowRate));
        }

        protected virtual void HealthCheck()
        {
            _healthBar.fillAmount = health / maxHealth;
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
