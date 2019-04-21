using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Service;

namespace Manager
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] Text levelText;
        [SerializeField] Text resourceText;
        [SerializeField] Text suppliesText;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            ReviseLevelUI();
            ReviseResourceUI();
            ReviseWalkUI();

            EventManager.Instance.onClearLevel += ReviseLevelUI;
            EventManager.Instance.onClearLevel += ReviseResourceUI;
            EventManager.Instance.onClearLevel += ReviseWalkUI;
            EventManager.Instance.onMove += ReviseResourceUI;
            EventManager.Instance.onMove += ReviseWalkUI;
            EventManager.Instance.onClick += ReviseResourceUI;
        }

        void ReviseLevelUI() => levelText.text = (LevelManager.Instance.level+1).ToString();
        void ReviseResourceUI() => resourceText.text = LevelManager.Instance.resource.ToString();
        void ReviseWalkUI() => suppliesText.text = LevelManager.Instance.walk.ToString() + "/" + LevelManager.Instance.maxWalk.ToString();
    }
}