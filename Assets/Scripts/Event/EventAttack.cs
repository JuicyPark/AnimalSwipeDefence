using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class EventAttack : MonoBehaviour
    {
        [SerializeField] Animal _animal;
        public void onEventAttack() => _animal.attackAble = true;
    }
}