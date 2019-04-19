using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class Warp : MonoBehaviour
    {
        public enum warpType { Start, In, Finish }
        [SerializeField] warpType type;
        [SerializeField] Transform targetPosition;

        void OnTriggerEnter(Collider collider)
        {
            if(type.Equals(warpType.In))
            {
                collider.transform.position = targetPosition.position;
                collider.transform.rotation = Quaternion.Euler(0, targetPosition.eulerAngles.y, 0);
            }
            else if(type.Equals(warpType.Finish))
            {
                LevelManager.Instance.life--;
                Destroy(collider.gameObject);
            }
        }

        void Start()
        {
            Debug.Log(targetPosition.eulerAngles.y);
        }
    }
}