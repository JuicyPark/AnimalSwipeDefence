using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace Manager
{
    public class LevelManager : Singleton<LevelManager>
    {
        public int level { get; private set; }
        public int resource { get; private set; }
        public int supplies { get; private set; }

        public int rewardResource = 10;
        public int priceAnimal = 3;
        public int priceMovig = 1;

        public event System.Action onclearLevel;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            level = 1;
            resource = 20;
            supplies = 0;

            onclearLevel += IncreaseLevel;
            onclearLevel += IncreaseResource;
        }

        public void ClearLevel()
        {
            onclearLevel?.Invoke();
        }

        void IncreaseLevel() => level++;
        public void IncreaseResource() => resource += rewardResource;
        public void DecreaseResource(int value) => resource -= value;
        public void IncreaseSupply() => supplies++;
        public void DecreaseSupply() => supplies--;
    }
}