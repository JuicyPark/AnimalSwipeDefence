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
        [SerializeField] Animator[] animalAnimators;
        [SerializeField] GameObject descriptionPanel;
        [SerializeField] float delay = 5f;
        public void OnStartButton()
        {
            _modeSelectPanel.SetActive(true);
            descriptionPanel.SetActive(false);
        }
        public void OnXButton() =>_modeSelectPanel.SetActive(false);

        void Start()
        {
            Screen.SetResolution(720, 1280, true);
            Time.timeScale = 1.2f;
            StartCoroutine(CRandomJump());
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnExitButton();
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
        public void OnExitButton() => Application.Quit();
        void LoadToSpeedScene() => _transition.SetTrigger("GoToSpeed");
        void LoadToInfinityScene() => _transition.SetTrigger("GoToInfinity");

        IEnumerator CRandomJump()
        {
            while(true)
            {
                yield return new WaitForSeconds(delay);
                animalAnimators[Random.Range(0, animalAnimators.Length)].SetTrigger("Jump");
            }
        }
    }
}
