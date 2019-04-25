using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class Animal : MonoBehaviour
    {
        public float damage;
        public float range;
        public Animator _animator;
        public bool attackAble;
        public LayerMask _enemyLayerMask = 1 << 9;
    }
}