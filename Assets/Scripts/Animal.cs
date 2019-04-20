using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class Animal : MonoBehaviour
    {
        [SerializeField] int damage;
        [SerializeField] int range;
        [SerializeField] Animator _animator;
        Ray[] ray = new Ray[4];
        RaycastHit _hit;
        public bool attackAble;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            attackAble = true;
            for (int i = 0; i < ray.Length; i++)
                ray[i].origin = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

            ray[0].direction = transform.forward;
            ray[1].direction = -transform.forward;
            ray[2].direction = transform.right;
            ray[3].direction = -transform.right;
        }

        void Update()
        {
            if (attackAble)
            {
                if (Physics.Raycast(ray[0].origin, ray[0].direction, out _hit, range))
                {
                    Attack(_hit);
                }
                else if (Physics.Raycast(ray[1].origin, ray[1].direction, out _hit, range))
                {
                    Attack(_hit);
                }
                else if (Physics.Raycast(ray[2].origin, ray[2].direction, out _hit, range))
                {
                    Attack(_hit);
                }
                else if (Physics.Raycast(ray[3].origin, ray[3].direction, out _hit, range))
                {
                    Attack(_hit);
                }
            }
        }

        void Attack(RaycastHit hit)
        {
            attackAble = false;
            transform.LookAt(hit.collider.transform);
            _animator.SetTrigger("isAttack");
            hit.collider.gameObject.GetComponent<Enemy>().Damage(damage);
        }
    }
}