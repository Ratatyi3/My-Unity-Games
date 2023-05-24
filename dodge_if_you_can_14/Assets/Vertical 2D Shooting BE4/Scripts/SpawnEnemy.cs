using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject boss;
    public GameObject[] bonuse4 = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        InvokeRepeating("spawnEnemy", 0, 0.6f);
        InvokeRepeating("bonuse", 0, 5);
    }
    public void notSpawn()
    {
        CancelInvoke("spawnEnemy");
    }

    public void notSpawnBonus()
    {
        CancelInvoke("bonuse");
    }

    public void spawnEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-3f, 3f), 10, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public void spawnBoss()
    {
        Instantiate(boss, new Vector3(0, 5, 0), Quaternion.Euler(0, 0, 0));
    }

    public void bonuse()
    {
        Instantiate(bonuse4[Random.Range(0, 4)], new Vector3(Random.Range(-3f, 3f), 10, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
