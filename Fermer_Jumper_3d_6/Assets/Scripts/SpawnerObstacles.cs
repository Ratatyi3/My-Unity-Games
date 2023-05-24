using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject biggerObstacle;
    public int obsTime = 4;
    public int bigObsTime = 8;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSpawnObstacles(int diff)
    {
        obstacle.GetComponent<MoveObstacles>().speed = diff;
        biggerObstacle.GetComponent<MoveObstacles>().speed = diff;
        print("start spawnObs srabotal");
        InvokeRepeating("spawnObstacles", 1, obsTime);
        InvokeRepeating("spawnBiggerObstacles", 2, bigObsTime);

        if (diff >= 20)
            respawnInvokeHard();
    }

    void spawnObstacles(){
        Instantiate(obstacle,new Vector3(30,0,0),Quaternion.Euler(new Vector3(0,0,0)));
    }
    void spawnBiggerObstacles(){
        Instantiate(biggerObstacle,new Vector3(Random.Range(30,40),0,0),Quaternion.Euler(new Vector3(0,0,0)));
    }

    public void respawnInvokeHard()
    {
        CancelInvoke();
        obsTime = 5;
        bigObsTime = 7;
        InvokeRepeating("spawnObstacles", 1, obsTime);
        InvokeRepeating("spawnBiggerObstacles", 5, bigObsTime);
    }

    public void stopInvoke(){
        CancelInvoke();
        print("stop srabotal");
    }
}
