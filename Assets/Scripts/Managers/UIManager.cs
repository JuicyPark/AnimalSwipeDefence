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

        public int maxSupplies = 15;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            LevelManager.Instance.onclearLevel += ReviseLevelUI;
            LevelManager.Instance.onclearLevel += ReviseResourceUI;
            BlockManager.Instance.onMove += ReviseResourceUI;
            ClickManager.Instance.onClick += ReviseResourceUI;
            ClickManager.Instance.onClick += ReviseSuppliesUI;
        }

        void ReviseLevelUI() => levelText.text = LevelManager.Instance.level.ToString();
        void ReviseResourceUI() => resourceText.text = LevelManager.Instance.resource.ToString();
        void ReviseSuppliesUI() => suppliesText.text = LevelManager.Instance.supplies.ToString() +" / "+ maxSupplies.ToString();
    }
}