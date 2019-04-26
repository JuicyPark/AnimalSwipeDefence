using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public class LobbyManager : MonoBehaviour
    {
        [SerializeField] Animator _transition;
        public void OnStartButton() => _transition.SetTrigger("isClose");


        public void OnOptionButton()
        {

        }

        public void OnExitButton() => Application.Quit();
    }
}
