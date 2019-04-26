using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGame
{
    public class EventSceneChange : MonoBehaviour
    {
        public void LoadScene0() => SceneManager.LoadScene(0);
        public void LoadScene1() => SceneManager.LoadScene(1);
        public void LoadScene2() => SceneManager.LoadScene(2);
    }
}