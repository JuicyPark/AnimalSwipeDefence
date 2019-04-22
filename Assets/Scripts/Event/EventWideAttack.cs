using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class EventWideAttack : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particleSystem;
        public void onEventWideAttack() => _particleSystem.Play();
    }
}