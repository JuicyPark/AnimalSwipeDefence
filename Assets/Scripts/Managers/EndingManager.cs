using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class EndingManager : MonoBehaviour
    {
        [SerializeField] Animator transitionAnimator;
        public void onEndGame() => transitionAnimator.SetTrigger("GoToLobby");
    }
}