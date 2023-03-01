using UnityEngine;
using Service;
using UnityEngine.AddressableAssets;

namespace Manager
{
    [System.Serializable]
    public class Level
    {
        public Sprite[] animalSprite;
        public AssetReference[] animalObject;
    }
    public class AnimalInformation : Singleton<AnimalInformation>
    {
        public Level[] level;
        public Sprite noneSprite;
    }
}
