using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;

namespace InGame
{
    public class Timer : Singleton<Timer>
    {
        public Text timerText;

        public int min = 0;
        public float second = 0;
        void FixedUpdate()
        {
            second += Time.deltaTime;
            if (second > 60)
            {
                min++;
                second = 0;
            }
            timerText.text = string.Format("{0:D2} : {1:D2}", min, (int)second);
        }
    }
}