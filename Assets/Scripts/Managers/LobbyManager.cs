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
        public void OnExitButton() => Application.Quit();
        void LoadToGameScene() => _transition.SetTrigger("isClose");

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
