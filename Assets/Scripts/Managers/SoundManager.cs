using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;
namespace Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] AudioSource selectSound;
        [SerializeField] AudioSource missionClearSound;
        [SerializeField] AudioSource stageClearSound;
        [SerializeField] AudioSource[] attackSound;
        [SerializeField] AudioSource decreaseLifeSound;
        void Start()
        {
            EventManager.Instance.onClick += SelectSoundPlay;
            EventManager.Instance.onMission += MissionClearSoundPlay;
            EventManager.Instance.onClearLevel += StageClearSoundPlay;
            EventManager.Instance.onMissMonster += DecreaseLifeSoundPlay;
        }

        public void SelectSoundPlay() => selectSound.Play();
        void MissionClearSoundPlay() => missionClearSound.Play();
        void StageClearSoundPlay() => stageClearSound.Play();
        public void DecreaseLifeSoundPlay() => decreaseLifeSound.Play();
        public void AttackSoundPlay()
        {
            for(int i=0;i< attackSound.Length;i++)
            {
                if(!attackSound[i].isPlaying)
                {
                    attackSound[i].Play();
                    return;
                }
            }
        }
    }
}