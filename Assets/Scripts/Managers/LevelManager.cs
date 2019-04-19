using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace Manager
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] Animator _cameraAnimator;

        public int level { get; private set; }
        public int resource { get; private set; }
        public int supplies { get; private set; }

        public enum LevelState { Ready, Battle }
        public LevelState currentState = LevelState.Ready;
        public int rewardResource = 10;
        public int priceAnimal = 3;
        public int priceMovig = 1;
        public int life = 30;

        public event System.Action onClearLevel;
        public event System.Action onStartLevel;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            level = 1;
            resource = 20;
            supplies = 0;
            
            onClearLevel += IncreaseLevel;
            onClearLevel += IncreaseResource;
        }

        public void ClearLevel()
        {
            onClearLevel?.Invoke();
        }

        void IncreaseLevel() => level++;
        public void IncreaseResource() => resource += rewardResource;
        public void DecreaseResource(int value) => resource -= value;
        public void IncreaseSupply() => supplies++;
        public void DecreaseSupply() => supplies--;

        public void StartLevel()
        {
            if (currentState.Equals(LevelState.Ready))
            {
                currentState = LevelState.Battle;
                _cameraAnimator.SetBool("isBattle", true);
                onStartLevel?.Invoke();

                // TODO : UI 내리기 (UI매니저)

                BlockManager.Instance.AnimalSpawn();
            }
        }
    }
}