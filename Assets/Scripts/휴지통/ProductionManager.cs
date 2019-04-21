using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;

namespace Manager
{
    /// <summary>
    /// 임시폐기
    /// </summary>
    public class ProductionManager : Singleton<ProductionManager>
    {
        [SerializeField] Light _light;
        public float duration = 1f;
        public float smoothness = 0.02f;
        Color currentColor;

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            currentColor = Color.white;
            EventManager.Instance.onMissMonster += WarningLight;
        }

        void WarningLight() => StartCoroutine(CWarningLight());

        IEnumerator CWarningLight()
        {
            float progress = 0;
            while (progress < 100)
            {
                _light.color = Color.Lerp(currentColor, Color.red, 5);
                progress += duration;
                yield return new WaitForSeconds(smoothness);
            }
        }
    }
}