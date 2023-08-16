using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies = null;
    
    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    [SerializeField]
    private float spwanInterval = 1.5f;
    private void Start()
    {
        StartEnemyRoutine();
    }

    private void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }
    /// <summary>
    /// 적 생성을 위한 코루틴
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            foreach (float posX in arrPosX)
            {
                int index = Random.Range(0,enemies.Length);
                SpawnEnemy(posX, index);
            }

            yield return new WaitForSeconds(spwanInterval);
        }
    }
    /// <summary>
    /// 생성 될 Pos X와 적 몬스터 배열 index를 받아 생성 
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="index"></param>
    private void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }

}
