using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] Transform _transform;
        void Update()
        {
            _transform.rotation = Quaternion.Euler(0, 135f, 0);
        }
    }
}