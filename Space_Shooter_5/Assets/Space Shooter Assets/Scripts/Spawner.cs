using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject asteroid;
    public GameObject[] bonuses = new GameObject[4];
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public void setHard()
    {
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0, 1);
    }

    public void startSpawn()
    {
        InvokeRepeating("SpawnEnemy", 0, 2);
        InvokeRepeating("SpawnAsteroid", 0, 10);
    }
    public void stopSpawn()
    {
        CancelInvoke();
    }

    void SpawnEnemy()
    {
        Vector3 randomPos = new Vector2(9,Random.Range(-4f,4f));
        Instantiate(enemy, randomPos, Quaternion.Euler(new Vector3(0,180,0)));
    }

    void SpawnAsteroid(){
        Vector3 randomPos = new Vector2(9,Random.Range(-4f,4f));
        Instantiate(asteroid, randomPos,Quaternion.Euler(new Vector3(0,180,0)));
    }

    public void SpawnBonuse()
    {
        Vector3 randomPos = new Vector2(9, Random.Range(-4f, 4f));
        int i = Random.Range(0, 4);
        GameObject clone = Instantiate(bonuses[i], randomPos, Quaternion.Euler(new Vector3(0, 180, 0)));
    }
}
