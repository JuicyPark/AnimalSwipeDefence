using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace Manager
{
    public class ModeManager : PersistentSingleton<ModeManager>
    {
        public int modeLevel;
    }
}