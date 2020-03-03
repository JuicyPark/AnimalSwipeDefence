using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class EventClickAble : MonoBehaviour
    {
        public void ClickAbleTrue() => BlockManager.Instance.clickAble = true;
        public void ClickAbleFalse() => BlockManager.Instance.clickAble = false;
    }
}