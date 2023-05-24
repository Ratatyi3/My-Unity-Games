using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyClone1;
    public GameObject enemyClone2;
    public int countEnemies;
    public GameObject[] bonuses = new GameObject[4];
    public bool startGame;

    public bool easySpawn;
    public bool mediumSpawn;
    public bool hardSpawn;

    public int countBoss;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
        easySpawn = false;
        mediumSpawn = false;
        hardSpawn = false;
        countEnemies = 1;
        countBoss = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (mediumSpawn || hardSpawn)
            {

                if (enemyClone1 != null)
                {
                    if (enemyClone1.transform.position.y < -5)
                    {
                        deleteEnemy(enemyClone1);
                    }
                }
                if( enemyClone2 != null)
                {
                    if (enemyClone2.transform.position.y < -5)
                    {
                        deleteEnemy(enemyClone2);
                    }
                }
                else if (enemyClone1 == null && enemyClone2 == null)
                    spawnEnemy();
            }
            else
            {
                if (enemyClone1.transform.position.y < -5)
                {
                    print("spawn solo");
                    deleteEnemy(enemyClone1);
                    spawnEnemy();
                }
            }
        }
    }

    public void spawnEnemy()
    {
        if (easySpawn)
            enemyClone1 = Instantiate(enemy, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(0, 0, 0)));
        else if (mediumSpawn)
        {
            enemyClone1 = Instantiate(enemy, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(0, 0, 0)));
            enemyClone2 = Instantiate(enemy, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else if (hardSpawn)
        {
            if (countBoss < 10)
            {
                enemyClone1 = Instantiate(enemy, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(0, 0, 0)));
                enemyClone2 = Instantiate(enemy, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            if (countBoss >= 10)
            {
                enemyClone1 = Instantiate(boss, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(0, 0, 0)));
            }

        }
        if(countBoss % 2 == 0 && countBoss != 0)
            Instantiate(bonuses[Random.Range(0, 4)], new Vector3(Random.Range(-5, 10), 0, Random.Range(-5, 10)), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public void deleteEnemy(GameObject a)
    {
        Destroy(a);
        countBoss++;
        GameObject.Find("GameManager").GetComponent<GameManager>().scoreNum += 1;
    }
}
