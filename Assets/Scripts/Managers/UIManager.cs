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
            LevelManager.Instance.onclearLevel += ReviseLevelUI;
            LevelManager.Instance.onclearLevel += ReviseResourceUI;
            MoveManager.Instance.onMove += ReviseResourceUI;
        }

        void ReviseLevelUI() => levelText.text = LevelManager.Instance.level.ToString();
        void ReviseResourceUI() => resourceText.text = LevelManager.Instance.resource.ToString();
        void ReviseSuppliesUI() => suppliesText.text = LevelManager.Instance.supplies.ToString();
    }
}