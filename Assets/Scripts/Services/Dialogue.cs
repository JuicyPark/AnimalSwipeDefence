using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    [System.Serializable]
    public class Dialogue
    {
        [TextArea(3, 10)]
        public string[] sentences;
    }
}