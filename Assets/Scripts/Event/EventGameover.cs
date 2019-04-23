using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class EventGameover : MonoBehaviour
    {
        [SerializeField] GameObject _challengePanel;
        public void SetChallengePanel()
        {
            _challengePanel.SetActive(true);
        }
    }
}