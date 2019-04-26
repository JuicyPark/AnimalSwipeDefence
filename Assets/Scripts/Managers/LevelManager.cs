using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;
using UnityEngine.UI;

namespace Manager
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] Animator _cameraAnimator;
        [SerializeField] Animator _bottomPanelAnimator;
        [SerializeField] Image _lifeBar;
        public enum LevelState { Ready, Battle }

        [Header("레벨")]
        public int level = 0;

        [Header("자원")]
        public int resource = 20;
        public int priceAnimal = 3;
        public int rewardResource = 10;

        [Header("이동")]
        public int walk = 10;
        public int priceWalk = 1;
        public int rewardWalk = 10;
        public int maxWalk = 20;

        [Header("재배치")]
        public int reverse = 5;
        public int maxReverse = 5;

        [Header("상태")]
        public int life = 30;
        public int maxLife = 30;
        public LevelState currentState = LevelState.Ready;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            EventManager.Instance.onClearLevel += IncreaseLevel;
            EventManager.Instance.onClearLevel += IncreaseResource;
            EventManager.Instance.onClearLevel += IncreaseWalk;
            EventManager.Instance.onClearLevel += IncreaseReverse;
            EventManager.Instance.onClearLevel += OnReady;
            EventManager.Instance.onMissMonster += DecreaseLife;
            EventManager.Instance.onMissMonster += LifeCheck;
            EventManager.Instance.onMissBoss += Decrease10Life;
            EventManager.Instance.onMissBoss += LifeCheck;
        }

        void DecreaseLife()
        {
            life--;
            _lifeBar.fillAmount = (float)life / maxLife;
        }

        void Decrease10Life()
        {
            life -= 10;
            _lifeBar.fillAmount = (float)life / maxLife;
        }

        void LifeCheck()
        {
            if (life <= 0)
            {
                UIManager.Instance._gameoverPanelAnimator.SetTrigger("isClose");
                EventManager.Instance.onLoseInvoke();
            }
        }
        void IncreaseLevel() => level++;
        public void IncreaseResource() => resource += rewardResource;
        public void DecreaseResource(int value) => resource -= value;
        public void IncreaseWalk()
        {
            walk += rewardWalk;
            if (walk > maxWalk)
                walk = maxWalk;
        }
        public void DecreaseWalk() => walk -= priceWalk;
        void IncreaseReverse()
        {
            reverse ++;
            if (reverse > maxReverse)
                reverse = maxReverse;
        }

        public void OnBattle()
        {
            if (currentState.Equals(LevelState.Ready))
            {
                SoundManager.Instance.SelectSoundPlay();
                currentState = LevelState.Battle;
                _cameraAnimator.SetBool("isBattle", true);
                _bottomPanelAnimator.SetBool("isBattle", true);
                BlockManager.Instance.AnimalSpawn();
                EventManager.Instance.onStartLevelInvoke();
            }
        }

        public void OnReady()
        {
            if (currentState.Equals(LevelState.Battle))
            {
                _cameraAnimator.SetBool("isBattle", false);
                _bottomPanelAnimator.SetBool("isBattle", false);
                while (BlockManager.Instance.animalObject.Count > 0)
                    Destroy(BlockManager.Instance.animalObject.Dequeue());
            }
        }
    }
}