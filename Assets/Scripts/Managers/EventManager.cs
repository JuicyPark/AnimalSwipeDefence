using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
using Service;
using System;

namespace Manager
{
    public class EventManager : Singleton<EventManager>
    {
        public event Action onMove;
        public event Action onClick;
        public event Action onClearLevel;
        public event Action onStartLevel;
        public event Action onMissMonster;
        public event Action onMissBoss;

        public void onMoveInvoke() => onMove?.Invoke();
        public void onClickInvoke() => onClick?.Invoke();
        public void onClearLevelInvoke() => onClearLevel?.Invoke();
        public void onStartLevelInvoke() => onStartLevel?.Invoke();
        public void onMissMonsterInvoke() => onMissMonster?.Invoke();
        public void onMissBossInvoke() => onMissBoss?.Invoke();
    }
}