using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies = null;

    [SerializeField] private GameObject boss = null;
    
    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    [SerializeField]
    private float spwanInterval = 1.5f;
    private void Start()
    {
        StartEnemyRoutine();
    }

    /// <summary>
    /// 코루틴을 실행하기 위한 기능
    /// </summary>
    private void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    /// <summary>
    /// 몬스터 생성을 멈추기 위한 기능 
    /// </summary>
    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
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
        float moveSpeed = 4f;
        
        while (true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }
            
            spawnCount++;
            
            if (spawnCount % 10 == 0)
            {
                enemyIndex++;
                moveSpeed += 2;

                if (enemyIndex >= enemies.Length)
                {
                    SpawnBoss();
                    enemyIndex = 0;
                    moveSpeed = 5f;
                }
            }
            yield return new WaitForSeconds(spwanInterval);
        }
    }
    /// <summary>
    /// 생성 될 Pos X와 적 몬스터 배열 index를 받아 생성 
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="index"></param>
    private void SpawnEnemy(float posX, int index, float moveSpeed)
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
        
        GameObject enemyObj = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    /// <summary>
    /// 보스 생성 기능
    /// </summary>
    private void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
