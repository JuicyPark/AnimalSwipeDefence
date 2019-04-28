using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace Manager
{
    public class LobbyManager : MonoBehaviour
    {
        [SerializeField] Animator _transition;
        [SerializeField] GameObject _modeSelectPanel;
        public void OnStartButton() => _modeSelectPanel.SetActive(true);
        public void OnXButton() =>_modeSelectPanel.SetActive(false);

        void Start()
        {
            Time.timeScale = 1;
        }

        public void OnEasyButton()
        {
            ModeManager.Instance.isEasyMode = true;
            LoadToGameScene();
        }
        public void OnHardButton()
        {
            ModeManager.Instance.isEasyMode = false;
            LoadToGameScene();
        }

        public void OnMissionButton()
        {

        }
        public void OnExitButton() => Application.Quit();
        void LoadToGameScene() => _transition.SetTrigger("isClose");
    }
}
