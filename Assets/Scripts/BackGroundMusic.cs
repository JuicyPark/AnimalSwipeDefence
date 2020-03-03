using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace Manager
{
    public class BackGroundMusic : Singleton<BackGroundMusic>
    {
        [SerializeField] AudioClip loseClip;
        [SerializeField] AudioClip winClip;
        [SerializeField] AudioSource _audioSourceBGM;
        [SerializeField] GameObject _soundManager;
        void Start()
        {
            EventManager.Instance.onLose += ChangeLoseClip;
            EventManager.Instance.onLose += DisableSoundManager;
        }

        void ChangeLoseClip()
        {
            _audioSourceBGM.clip = loseClip;
            _audioSourceBGM.Play();
            _audioSourceBGM.loop = false;
            EventManager.Instance.onLose -= ChangeLoseClip;
        }
        void DisableSoundManager()
        {
            _soundManager.SetActive(false);
            EventManager.Instance.onLose -= DisableSoundManager;
        }
    }
}