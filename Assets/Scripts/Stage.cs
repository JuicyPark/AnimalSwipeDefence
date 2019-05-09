using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class Stage : MonoBehaviour
    {
        bool isAllSpawn = false;

        [Header("적 정보")]
        [SerializeField] GameObject enemyObject;
        [SerializeField] int enemyNumber;
        public float health;
        [Header("스폰 딜레이 시간")]
        [SerializeField] float delayTime;

        public void StartStage() => StartCoroutine(CSpawnEnemy());

        void OnTransformChildrenChanged()
        {
            if (isAllSpawn && transform.childCount == 0 && LevelManager.Instance.level<StageManager.Instance.stages.Length-1)
                EventManager.Instance.onClearLevelInvoke();
        }

        IEnumerator CSpawnEnemy()
        {
            for (int i = 0; i < enemyNumber; i++)
            {
                yield return new WaitForSeconds(delayTime);
                GameObject enemy = Instantiate(enemyObject, StageManager.Instance.warps[0].position, 
                    Quaternion.Euler(0, StageManager.Instance.warps[0].parent.eulerAngles.y, 0));
                enemy.transform.SetParent(transform);
                enemy.GetComponent<Enemy>().maxHealth = health * StageManager.Instance.healthRate;
                enemy.GetComponent<Enemy>().health = health * StageManager.Instance.healthRate;
            }
            isAllSpawn = true;
        }
    }
}