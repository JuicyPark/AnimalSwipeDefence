using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;

namespace Manager
{
    public class Timer : Singleton<Timer>
    {
        [SerializeField] float seconds = 20f;
        [SerializeField] float readyTime = 15f;
        [SerializeField] Text _text;

        public bool isStage = false;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            EventManager.Instance.onClearLevel += SetTimer;
        }

        public void SetTimer()
        {
            seconds = readyTime;
            isStage = false;
        }

        void FixedUpdate()
        {
            if (!isStage)
            {
                if (seconds > 0)
                {
                    seconds -= Time.deltaTime;
                    _text.text = ((int)seconds).ToString();
                }
                else
                {
                    EventManager.Instance.onStartLevelInvoke();
                    isStage = true;
                    seconds = 0;
                }
            }
        }
    }
}