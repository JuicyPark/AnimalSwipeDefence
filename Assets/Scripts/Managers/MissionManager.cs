using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
using Service;
using UnityEngine.UI;

namespace Manager
{
    public class MissionManager : Singleton<MissionManager>
    {
        [SerializeField] Animator missionAnimator;
        [SerializeField] Image missionIcon;
        [SerializeField] Text missionText;

        public MissionTrigger[] mission;

        void Start()
        {
            EventManager.Instance.onClick += MissionCheck0;
            EventManager.Instance.onClick += MissionCheck1;
            EventManager.Instance.onClick += MissionCheck2;
            EventManager.Instance.onClick += MissionCheck3;
            EventManager.Instance.onMove += MissionCheck3;
            EventManager.Instance.onMissMonster += MissionCheck4;
            EventManager.Instance.onMissBoss += MissionCheck4;
            EventManager.Instance.onClick += MissionCheck5;
            EventManager.Instance.onBossClear += MissionCheck6;
            EventManager.Instance.onBossClear += MissionCheck7;
            EventManager.Instance.onBossClear += MissionCheck8;
            EventManager.Instance.onBossClear += FinalBossClear;
        }

        public void ClearMission(Sprite sprite, string missionText, int reward)
        {
            BlockManager.Instance.clickAble = false;
            missionIcon.sprite = sprite;
            this.missionText.text = missionText;
            missionAnimator.SetTrigger("IsOpen");
            LevelManager.Instance.resource += reward;
            EventManager.Instance.onMissionInvoke();
        }

        public void MissionCheck0()
        {
            if (BlockManager.Instance.dogNumber.Equals(3))
            {
                mission[0].TriggerMission();
                EventManager.Instance.onClick -= MissionCheck0;
            }
        }
        public void MissionCheck1()
        {
            if (BlockManager.Instance.catNumber.Equals(3))
            {
                mission[1].TriggerMission();
                EventManager.Instance.onClick -= MissionCheck1;
            }
        }
        public void MissionCheck2()
        {
            if (BlockManager.Instance.selectBlock.animalLevel.Equals(2)&& BlockManager.Instance.selectBlock.animalIndex.Equals(6))
            {
                mission[2].TriggerMission();
                EventManager.Instance.onClick -= MissionCheck2;
            }
        }
        public void MissionCheck3()
        {
            if (LevelManager.Instance.resource==1)
            {
                mission[3].TriggerMission();
                EventManager.Instance.onClick -= MissionCheck3;
                EventManager.Instance.onMove -= MissionCheck3;
            }
        }
        public void MissionCheck4()
        {
            if (LevelManager.Instance.life <= 5)
            {
                mission[4].TriggerMission();
                EventManager.Instance.onMissBoss -= MissionCheck4;
                EventManager.Instance.onMissMonster -= MissionCheck4;
            }
        }
        public void MissionCheck5()
        {
            if (BlockManager.Instance.selectBlock.animalLevel.Equals(4))
            {
                mission[5].TriggerMission();
                EventManager.Instance.onClick -= MissionCheck5;
            }
        }
        public void MissionCheck6()
        {
            if (LevelManager.Instance.level.Equals(9))
            {
                mission[6].TriggerMission();
                EventManager.Instance.onBossClear -= MissionCheck6;
            }
        }
        public void MissionCheck7()
        {
            if (LevelManager.Instance.level.Equals(19))
            {
                mission[7].TriggerMission();
                EventManager.Instance.onBossClear -= MissionCheck7;
            }
        }
        public void MissionCheck8()
        {
            if (LevelManager.Instance.level.Equals(29))
            {
                mission[8].TriggerMission();
                EventManager.Instance.onBossClear -= MissionCheck8;
            }
        }
        public void FinalBossClear()
        {
            if (LevelManager.Instance.level.Equals(StageManager.Instance.stages.Length-1))
                UIManager.Instance._transitionPanelAnimator.SetTrigger("Ending");
        }
        public void FinalBossFail() => EventManager.Instance.onLoseInvoke();
    }
}
