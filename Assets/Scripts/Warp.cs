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
            if(!type.Equals(warpType.Finish))
            {
                collider.transform.position = targetPosition.position;
                collider.transform.rotation = Quaternion.Euler(0, targetPosition.parent.eulerAngles.y, 0);
            }
            else
            {
                EventManager.Instance.onMissMonsterInvoke();
                Destroy(collider.gameObject);
            }
        }
    }
}