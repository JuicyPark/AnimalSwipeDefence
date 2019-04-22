using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class Stage : MonoBehaviour
    {
        bool isAllSpawn = false;
        float delayWarpTime = 0.75f;
        Vector3 defaultDirection = new Vector3(0, 0, 90f);

        [Header("적 정보")]
        [SerializeField] GameObject enemyObject;
        [SerializeField] int enemyNumber;
        [SerializeField] int health;
        [Header("스폰 딜레이 시간")]
        [SerializeField] float delayTime;
        [Header("스테이지 워프 위치")]
        [SerializeField] Transform[] warpPosition;

        public void SetWarp() => StartCoroutine(CSetWarp());
        public void StartStage() => StartCoroutine(CSpawnEnemy());

        void OnTransformChildrenChanged()
        {
            if (isAllSpawn && transform.childCount == 0)
                EventManager.Instance.onClearLevelInvoke();
        }

        IEnumerator CSetWarp()
        {
            yield return new WaitForSeconds(delayWarpTime);
            for (int i = 0; i < warpPosition.Length; i++)
            {
                yield return new WaitForSeconds(delayWarpTime);
                StageManager.Instance.warps[i].SetParent(warpPosition[i]);
                StageManager.Instance.warps[i].gameObject.SetActive(true);
                StageManager.Instance.warps[i].localPosition = Vector3.zero;
                StageManager.Instance.warps[i].localEulerAngles = defaultDirection;
            }
        }
        IEnumerator CSpawnEnemy()
        {
            for (int i = 0; i < enemyNumber; i++)
            {
                yield return new WaitForSeconds(delayTime);
                GameObject enemy = Instantiate(enemyObject, warpPosition[0].position, 
                    Quaternion.Euler(0, warpPosition[0].eulerAngles.y, 0));
                enemy.transform.SetParent(transform);
                enemy.GetComponent<Enemy>().health = health;
            }
            isAllSpawn = true;
        }
    }
}