using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBonuses : MonoBehaviour
{
    public GameObject[] bonuses = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void spawnBonuses()
    {
        GameObject bonus = bonuses[Random.Range(0, 4)];
        Instantiate(bonus, new Vector3(Random.Range(17, 40), 1, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public void startSpawnBonuses()
    {
        InvokeRepeating("spawnBonuses",5, 5);
    }

    public void stopSpawnBonuses()
    {
        CancelInvoke();
    }
}
