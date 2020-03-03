using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class WideAttack : MonoBehaviour
    {
        [SerializeField] Animal _animal;
        [SerializeField] bool isSlow;
        [SerializeField] float slowRate;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            _animal.attackAble = true;
        }

        void Update()
        {
            if (_animal.attackAble)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, _animal.range, _animal._enemyLayerMask);
                if(hitColliders.Length!=0)
                    Attack(hitColliders);
            }
        }
        void Attack(Collider[] colliders)
        {
            SoundManager.Instance.AttackSoundPlay();
            _animal.attackAble = false;
            transform.LookAt(colliders[0].transform);
            _animal._animator.SetTrigger("isAttack");
            foreach (Collider collider in colliders)
            {
                if(isSlow)
                    collider.gameObject.GetComponent<Enemy>().Damage(_animal.damage, isSlow, slowRate);
                else
                    collider.gameObject.GetComponent<Enemy>().Damage(_animal.damage);
            }
        }
    }
}
