using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;

namespace Manager
{
    public class LobbyManager : Singleton<LobbyManager>
    {
        public bool isPanelActive;
        [SerializeField] Animator _transition;
        [SerializeField] GameObject _modeSelectPanel;
        [SerializeField] GameObject _rankingPanel;
        [SerializeField] GameObject _exitPanel;
        [SerializeField] Animator[] animalAnimators;
        [SerializeField] GameObject descriptionPanel;
        [SerializeField] Text[] rankingText;
        [SerializeField] float delay = 5f;
        public void OnRankingButton()
        {
            isPanelActive = true;
            _rankingPanel.SetActive(true);
            descriptionPanel.SetActive(false);
        }
        public void OnExitButton()
        {
            isPanelActive = true;
            _exitPanel.SetActive(true);
            descriptionPanel.SetActive(false);
        }
        public void OnStartButton()
        {
            isPanelActive = true;
            _modeSelectPanel.SetActive(true);
            descriptionPanel.SetActive(false);
        }
        public void OnXButton()
        {
            isPanelActive = false;
            _rankingPanel.SetActive(false);
            _modeSelectPanel.SetActive(false);
            _exitPanel.SetActive(false);
        }
        void Start()
        {
            Screen.SetResolution(720, 1280, true);
            Time.timeScale = 1.2f;
            StartCoroutine(CRandomJump());
            rankingText[0].text = (PlayerPrefs.GetInt("Easy") / 60).ToString() +" : " + (PlayerPrefs.GetInt("Easy") % 60).ToString();
            rankingText[1].text = (PlayerPrefs.GetInt("Normal") / 60).ToString() + " : " + (PlayerPrefs.GetInt("Normal") % 60).ToString();
            rankingText[2].text = (PlayerPrefs.GetInt("Hard") / 60).ToString() + " : " + (PlayerPrefs.GetInt("Hard") % 60).ToString();
            rankingText[3].text = PlayerPrefs.GetInt("Infinity").ToString();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPanelActive)
                OnExitButton();
            else if (Input.GetKeyDown(KeyCode.Escape) && isPanelActive)
                OnXButton();
        }
        public void OnEasyButton()
        {
            ModeManager.Instance.modeLevel = 0;
            LoadToSpeedScene();
        }
        public void OnNormalButton()
        {
            ModeManager.Instance.modeLevel = 1;
            LoadToSpeedScene();
        }
        public void OnHardButton()
        {
            ModeManager.Instance.modeLevel = 2;
            LoadToSpeedScene();
        }
        public void OnInfinityButton()
        {
            ModeManager.Instance.modeLevel = 3;
            LoadToInfinityScene();
        }
        public void OnExitReallyButton() => Application.Quit();
        void LoadToSpeedScene() => _transition.SetTrigger("GoToSpeed");
        void LoadToInfinityScene() => _transition.SetTrigger("GoToInfinity");

        IEnumerator CRandomJump()
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                animalAnimators[Random.Range(0, animalAnimators.Length)].SetTrigger("Jump");
            }
        }
    }
}
