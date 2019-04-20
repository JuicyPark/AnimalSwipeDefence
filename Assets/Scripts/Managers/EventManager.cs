using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
using Service;

namespace Manager
{
    public class EventManager : Singleton<EventManager>
    {
        public event System.Action onMove;
        public event System.Action onClick;
        public event System.Action onClearLevel;
        public event System.Action onStartLevel;

        public void onMoveInvoke() => onMove?.Invoke();
        public void onClickInvoke() => onClick?.Invoke();
        public void onClearLevelInvoke() => onClearLevel?.Invoke();
        public void onStartLevelInvoke() => onStartLevel?.Invoke();
    }
}