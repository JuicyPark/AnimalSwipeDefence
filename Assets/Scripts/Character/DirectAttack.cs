using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class DirectAttack : MonoBehaviour
    {
        [SerializeField] Animal _animal;
        [SerializeField] bool isSlow;
        [SerializeField] float slowRate;

        Ray[] ray = new Ray[4];
        RaycastHit _hit;
        
        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            _animal.attackAble = true;
            for (int i = 0; i < ray.Length; i++)
                ray[i].origin = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

            ray[0].direction = transform.forward;
            ray[1].direction = -transform.forward;
            ray[2].direction = transform.right;
            ray[3].direction = -transform.right;
        }
        void Update()
        {
            if (_animal.attackAble)
            {
                if (Physics.Raycast(ray[0].origin, ray[0].direction, out _hit, _animal.range, _animal._enemyLayerMask))
                {
                    Attack(_hit);
                }
                else if (Physics.Raycast(ray[1].origin, ray[1].direction, out _hit, _animal.range, _animal._enemyLayerMask))
                {
                    Attack(_hit);
                }
                else if (Physics.Raycast(ray[2].origin, ray[2].direction, out _hit, _animal.range, _animal._enemyLayerMask))
                {
                    Attack(_hit);
                }
                else if (Physics.Raycast(ray[3].origin, ray[3].direction, out _hit, _animal.range, _animal._enemyLayerMask))
                {
                    Attack(_hit);
                }
            }
        }

        void Attack(RaycastHit hit)
        {
            SoundManager.Instance.AttackSoundPlay();
            _animal.attackAble = false;
            transform.LookAt(hit.collider.transform);
            _animal._animator.SetTrigger("isAttack");
            if (isSlow)
                hit.collider.gameObject.GetComponent<Enemy>().Damage(_animal.damage, isSlow, slowRate);
            else
                hit.collider.gameObject.GetComponent<Enemy>().Damage(_animal.damage);
        }
    }
}