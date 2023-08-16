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

        int spawnCount = 0;
        int enemyIndex = 0;
        
        
        while (true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex);
            }
            
            spawnCount++;
            
            if (spawnCount % 10 == 0)
            {
                enemyIndex++;
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

        if (Random.Range(0, 5) == 0)
        {
            index++;
        }        
        
        if (index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }

}
