using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;
using InGame;

namespace Manager
{
    public class StageManager : Singleton<StageManager>
    {
        int currentStage;

        [SerializeField] Stage[] stages;

        public Transform[] warps;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            SetWarpTrigger();
            EventManager.Instance.onClearLevel += DisableWarps;
            EventManager.Instance.onClearLevel += SetWarpTrigger;
            EventManager.Instance.onStartLevel += StartStageTrigger;
        }

        public void SetWarpTrigger()
        {
            currentStage = LevelManager.Instance.level;
            stages[currentStage].SetWarp();
        }

        void DisableWarps()
        {
            for (int i = 0; i < warps.Length; i++)
                warps[i].gameObject.SetActive(false);
        }

        void StartStageTrigger() => stages[currentStage].StartStage();
    }
}
