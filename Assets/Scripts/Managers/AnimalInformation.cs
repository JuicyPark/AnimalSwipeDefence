using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;
using UnityEngine.UI;

namespace Manager
{
    [System.Serializable]
    public class Level
    {
        public Sprite[] animalSprite;
    }
    public class AnimalInformation : Singleton<AnimalInformation>
    {
        public Level[] level;
        public Sprite noneSprite;
    }
}
