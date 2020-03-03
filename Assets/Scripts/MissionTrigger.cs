using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.UI;

namespace InGame
{
    public class MissionTrigger : MonoBehaviour
    {
        [SerializeField] Sprite sprite;
        [TextArea(3, 10)]
        [SerializeField] string missionText;
        [SerializeField] int reward;

        public void TriggerMission() => MissionManager.Instance.ClearMission(sprite, missionText,reward);
    }
}