using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Manager
{
    public class EndingManager : MonoBehaviour
    {
        [SerializeField] Animator transitionAnimator;
        [SerializeField] Text timeText;
        [SerializeField] Text modeText;
        int speedScore;
        public void onEndGame() => transitionAnimator.SetTrigger("GoToLobby");

        void Start()
        {
            speedScore = ModeManager.Instance.speedMin * 60 + (int)ModeManager.Instance.speedSec;
            timeText.text = string.Format("{0:D2} : {1:D2}", speedScore / 60, speedScore % 60);
            if (ModeManager.Instance.modeLevel == 0)
            {
                modeText.text = "EASY MODE";
                if (speedScore <= PlayerPrefs.GetInt("Easy", 999999))
                    PlayerPrefs.SetInt("Easy", speedScore);
            }
            else if (ModeManager.Instance.modeLevel == 1)
            {
                modeText.text = "NORMAL MODE";
                if (speedScore <= PlayerPrefs.GetInt("Normal", 999999))
                    PlayerPrefs.SetInt("Normal", speedScore);
            }
            else if (ModeManager.Instance.modeLevel == 2)
            {
                modeText.text = "HARD MODE";
                if (speedScore <= PlayerPrefs.GetInt("Hard", 999999))
                    PlayerPrefs.SetInt("Hard", speedScore);
            }
        }
    }
}