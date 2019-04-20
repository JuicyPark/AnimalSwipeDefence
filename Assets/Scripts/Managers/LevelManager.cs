using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace Manager
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] Animator _cameraAnimator;
        [SerializeField] Animator _BottomPanelAnimator;

        public int level { get; private set; }
        public int resource { get; private set; }
        public int walk { get; private set; }

        public enum LevelState { Ready, Battle }
        public LevelState currentState = LevelState.Ready;
        public int rewardResource = 10;
        public int rewardWalk = 10;
        public int priceAnimal = 3;
        public int priceWalk = 1;
        public int life = 30;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            level = 0;
            resource = 20;
            walk = 10;
            
            EventManager.Instance.onClearLevel += IncreaseLevel;
            EventManager.Instance.onClearLevel += IncreaseResource;
            EventManager.Instance.onClearLevel += IncreaseWalk;
        }

        void IncreaseLevel() => level++;
        public void IncreaseResource() => resource += rewardResource;
        public void DecreaseResource(int value) => resource -= value;
        public void IncreaseWalk() => walk += rewardWalk;
        public void DecreaseWalk() => walk -= priceWalk;

        public void PressBattle()
        {
            if (currentState.Equals(LevelState.Ready))
            {
                currentState = LevelState.Battle;
                _cameraAnimator.SetBool("isBattle", true);
                _BottomPanelAnimator.SetBool("isBattle", true);
                BlockManager.Instance.AnimalSpawn();
            }
        }
        public void PressReady()
        {
            if (currentState.Equals(LevelState.Battle))
            {
                currentState = LevelState.Ready;
                _cameraAnimator.SetBool("isBattle", false);
                _BottomPanelAnimator.SetBool("isBattle", false);
                while (BlockManager.Instance.animalObject.Count > 0)
                    Destroy(BlockManager.Instance.animalObject.Dequeue());
            }
        }
    }
}