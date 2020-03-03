using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] Text levelText;
        [SerializeField] Text resourceText;
        [SerializeField] Text walkText;
        [SerializeField] Text _accelerationText;

        [SerializeField] Image levelImage;
        [SerializeField] Sprite[] enemySprites;

        [SerializeField] Animator _levelAnimator;
        [SerializeField] Animator _resourceAnimator;
        [SerializeField] Animator _walkAnimator;
        [SerializeField] Animator _stageClearAnimator;

        [SerializeField] GameObject[] grounds;
        [SerializeField] GameObject _reverseButton;
        [SerializeField] GameObject _exitPanel;
        [SerializeField] GameObject _modePanel;

        [SerializeField] GameObject _accelerationPanel;
        [SerializeField] float acceleration = 2.2f;
        float _tempTimeScale;
        public Animator _transitionPanelAnimator;
        void Start()
        {
            Initialize();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnExitButton();
        }

        void Initialize()
        {
            Time.timeScale = 1.2f;

            EventManager.Instance.onClearLevel += ReviseLevelUI;
            EventManager.Instance.onClearLevel += ReviseResourceUI;
            EventManager.Instance.onClearLevel += ReviseWalkUI;
            EventManager.Instance.onClearLevel += ReviseGround;
            EventManager.Instance.onClearLevel += AnimateLevelUI;
            EventManager.Instance.onClearLevel += AnimateStageClear;
            EventManager.Instance.onMove += ReviseResourceUI;
            EventManager.Instance.onMove += ReviseWalkUI;
            EventManager.Instance.onClick += ReviseResourceUI;
            EventManager.Instance.onMission += ReviseResourceUI;
            EventManager.Instance.onStartLevel += DisableReverseButton;
            EventManager.Instance.onWarpSetting += ReviseReverse;
            EventManager.Instance.onLose += AnimateStageLose;

            ReviseResourceUI();
            ReviseWalkUI();
            ReviseGround();

            if (ModeManager.Instance.modeLevel == 3)
                EventManager.Instance.onClearLevel -= ReviseGround;

            //if (PlayerPrefs.GetInt("Clear").Equals(1))
            //    _accelerationPanel.SetActive(true);

            if (ModeManager.Instance.modeLevel == 0)
            {
                _modePanel.GetComponent<Text>().text = "EASY MODE";
            }
            else if (ModeManager.Instance.modeLevel == 1)
            {
                _modePanel.GetComponent<Text>().text = "NORMAL MODE";
            }
            else if (ModeManager.Instance.modeLevel == 2)
            {
                _modePanel.GetComponent<Text>().text = "HARD MODE";
            }
            else if (ModeManager.Instance.modeLevel == 3)
            {
                _modePanel.GetComponent<Text>().text = "INFINITY MODE";
                EventManager.Instance.onClearLevel -= ReviseLevelUI;
                EventManager.Instance.onClearLevel += ReviseLevelUI_Infinity;
                return;
            }
            ReviseLevelUI();
        }

        public void ExitScene() => SceneManager.LoadScene(0);
        public void RetryScene()
        {
            if (ModeManager.Instance.modeLevel == 3)
                SceneManager.LoadScene(2);
            else
                SceneManager.LoadScene(1);
        }
        void ReviseLevelUI()
        {
            levelText.text = "<color=black>Lv.</color> " + (LevelManager.Instance.level + 1).ToString();
            levelImage.sprite = enemySprites[LevelManager.Instance.level];
        }
        void ReviseLevelUI_Infinity() => levelText.text = "<color=black>Lv.</color> " + (LevelManager.Instance.level + 1).ToString();
        void ReviseResourceUI() => resourceText.text = LevelManager.Instance.resource.ToString() + "<color=yellow>G</color>";
        void ReviseWalkUI() => walkText.text = LevelManager.Instance.walk.ToString() + "/" + LevelManager.Instance.maxWalk.ToString();
        void ReviseReverse()
        {
            if (LevelManager.Instance.reverse == LevelManager.Instance.maxReverse) _reverseButton.SetActive(true);
        }
        void AnimateLevelUI() => _levelAnimator.SetTrigger("isRevise");
        public void AnimateResourceUI() => _resourceAnimator.SetTrigger("isRevise");
        public void AnimateWalkUI() => _walkAnimator.SetTrigger("isRevise");
        public void AnimateStageClear() => _stageClearAnimator.SetTrigger("isOpen");
        public void AnimateStageLose() => _transitionPanelAnimator.SetTrigger("isClose");
        public void DisableReverseButton() => _reverseButton.SetActive(false);

        public void OnReverseButton()
        {
            DisableReverseButton();
            LevelManager.Instance.reverse = 0;
            StageManager.Instance.SetRandomPosition();
            StageManager.Instance.SetWarpTrigger();
        }

        public void OnGoToLobby()
        {
            Time.timeScale = 1.2f;
            _transitionPanelAnimator.SetTrigger("Lobby");
        }
        public void OnExitButton()
        {
            if (!_exitPanel.activeSelf)
            {
                _tempTimeScale = Time.timeScale;
                _exitPanel.SetActive(true);
                BlockManager.Instance.clickAble = false;
                Time.timeScale = 0;
            }
            else
            {
                _exitPanel.SetActive(false);
                BlockManager.Instance.clickAble = true;
                Time.timeScale = _tempTimeScale;
            }
        }

        public void OnAccelationButton()
        {
            if (Time.timeScale.Equals(1.2f))
            {
                Time.timeScale = acceleration;
                _accelerationText.text = "-";
            }
            else
            {
                Time.timeScale = 1.2f;
                _accelerationText.text = ">>";
            }
        }
        void ReviseGround()
        {

            if (LevelManager.Instance.level >= 30)
            {
                grounds[0].SetActive(false);
                grounds[1].SetActive(false);
                grounds[2].SetActive(false);
                grounds[3].SetActive(true);
            }
            else if (LevelManager.Instance.level >= 20)
            {
                grounds[0].SetActive(false);
                grounds[1].SetActive(false);
                grounds[2].SetActive(true);
                grounds[3].SetActive(false);
            }
            else if (LevelManager.Instance.level >= 10)
            {
                grounds[0].SetActive(false);
                grounds[1].SetActive(true);
                grounds[2].SetActive(false);
                grounds[3].SetActive(false);
            }
            else
            {
                grounds[0].SetActive(true);
                grounds[1].SetActive(false);
                grounds[2].SetActive(false);
                grounds[3].SetActive(false);
            }
        }
    }
}