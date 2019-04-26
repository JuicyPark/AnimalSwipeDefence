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

        void Start()
        {
            EventManager.Instance.onClick += SelectSoundPlay;
            EventManager.Instance.onMission += MissionClearSoundPlay;
            EventManager.Instance.onClearLevel += StageClearSoundPlay;
        }

        public void SelectSoundPlay() => selectSound.Play();
        void MissionClearSoundPlay() => missionClearSound.Play();
        void StageClearSoundPlay() => stageClearSound.Play();

    }
}