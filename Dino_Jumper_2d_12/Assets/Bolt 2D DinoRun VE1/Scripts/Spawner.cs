using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cactuses = new GameObject[2];
    public GameObject[] bonuses = new GameObject[4];
    public GameObject secondLose;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSpawn(int dif)
    {
        speed = dif;
        InvokeRepeating("spawn", 0, 4);
        InvokeRepeating("spawnBonus", 5, 5);
        InvokeRepeating("spawnLose", 10, 10);
    }

    public void stopSpawn()
    {
        CancelInvoke();
    }


    public void spawn()
    {
        Instantiate(cactuses[Random.Range(0, 2)], new Vector3(Random.Range(6f, 22f),1,0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    public void spawnBonus()
    {
        Instantiate(bonuses[Random.Range(0, 4)], new Vector3(Random.Range(6f, 22f), 1.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public void spawnLose()
    {
        Instantiate(secondLose, new Vector3(Random.Range(6f, 22f), 2.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
