using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class SynergyAttack : MonoBehaviour
    {
        [SerializeField] Animal _animal;
        [SerializeField] Animator _animator;
        public enum animalType { Cat,Dog,Bear}
        public animalType type;
        void Start()
        {
            float synergy = 1f;
            if (type.Equals(animalType.Cat))
                synergy -= BlockManager.Instance.catNumber * 0.18f;
            else if (type.Equals(animalType.Dog))
                synergy += BlockManager.Instance.dogNumber * 0.18f;
            else if (type.Equals(animalType.Bear))
                synergy += BlockManager.Instance.bearNumber * 0.25f;

            if (synergy > 2f) synergy = 2f;
            else if (synergy < 0.5f) synergy = 0.5f;
            _animal.damage *= synergy;
        }
    }
}