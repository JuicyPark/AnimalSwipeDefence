using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class EventStateChange : MonoBehaviour
    {
        public void SetStateReady() => LevelManager.Instance.currentState = LevelManager.LevelState.Ready;
    }
}