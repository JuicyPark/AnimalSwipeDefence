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
        [SerializeField] Image levelImage;
        [SerializeField] Sprite[] enemySprites;
        [SerializeField] GameObject[] grounds;
        [SerializeField] Animator _levelAnimator;
        [SerializeField] Animator _resourceAnimator;
        [SerializeField] Animator _walkAnimator;
        [SerializeField] Animator _stageClearAnimator;
        [SerializeField] GameObject _reverseButton;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            Screen.SetResolution(720, 1280, true);
            ReviseLevelUI();
            ReviseResourceUI();
            ReviseWalkUI();
            ReviseGround();

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
        }

        public void ExitScene() => SceneManager.LoadScene(0);
        public void RetryScene() => SceneManager.LoadScene(1);
        void ReviseLevelUI()
        {
            levelText.text = "<color=black>Lv.</color> " + (LevelManager.Instance.level + 1).ToString();
            levelImage.sprite = enemySprites[LevelManager.Instance.level];
        }
        void ReviseResourceUI() => resourceText.text = LevelManager.Instance.resource.ToString() + "<color=yellow>G</color>";
        void ReviseWalkUI() => walkText.text = LevelManager.Instance.walk.ToString() + "/" + LevelManager.Instance.maxWalk.ToString();
        void ReviseReverse()
        {
            if (LevelManager.Instance.reverse == 5) _reverseButton.SetActive(true);
        }
        void AnimateLevelUI() => _levelAnimator.SetTrigger("isRevise");
        public void AnimateResourceUI() => _resourceAnimator.SetTrigger("isRevise");
        public void AnimateWalkUI() => _walkAnimator.SetTrigger("isRevise");
        public void AnimateStageClear() => _stageClearAnimator.SetTrigger("isOpen");
        public void DisableReverseButton() => _reverseButton.SetActive(false);
        public void OnReverseButton()
        {
            DisableReverseButton();
            LevelManager.Instance.reverse = 0;
            StageManager.Instance.SetRandomPosition();
            StageManager.Instance.SetWarpTrigger();
        }
        void ReviseGround()
        {
            if(LevelManager.Instance.level>=30)
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