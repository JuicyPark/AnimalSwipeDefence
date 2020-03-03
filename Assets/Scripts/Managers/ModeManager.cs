using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace Manager
{
    public class ModeManager : PersistentSingleton<ModeManager>
    {
        public int modeLevel;
        public int speedMin;
        public float speedSec;
        public int InfinityScore;
    }
}