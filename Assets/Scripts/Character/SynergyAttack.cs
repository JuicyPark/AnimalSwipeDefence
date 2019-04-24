using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class SynergyAttack : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        public enum animalType { Cat,Dog,Bear}
        public animalType type;
        void Start()
        {
            float attackSpeed = 1f;
            if (type.Equals(animalType.Cat))
                attackSpeed -= BlockManager.Instance.catNumber * 0.15f;
            else if (type.Equals(animalType.Dog))
                attackSpeed += BlockManager.Instance.dogNumber * 0.15f;
            else if (type.Equals(animalType.Bear))
                attackSpeed += BlockManager.Instance.bearNumber * 0.15f;

            if (attackSpeed > 1.9f) attackSpeed = 2;
            else if (attackSpeed < 0.5f) attackSpeed = 0.4f;
            _animator.SetFloat("AttackSpeed", attackSpeed);
        }
    }
}