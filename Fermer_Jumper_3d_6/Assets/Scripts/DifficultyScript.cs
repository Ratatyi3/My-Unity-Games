using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour
{
    public int difficulty;
    private SpawnerObstacles spawnerObs;
    private SpawnerBonuses spawnerBonuses;
    private MoveBackground moveBack;
    private PlayerController playerController;
    private Canvas c;
    public string a;

    // Start is called before the first frame update
    void Start()
    {
        moveBack = GameObject.Find("Background").GetComponent<MoveBackground>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnerObs = GameObject.Find("Spawner").GetComponent<SpawnerObstacles>();
        spawnerBonuses = GameObject.Find("Spawner").GetComponent<SpawnerBonuses>();
        c = GameObject.Find("GameManager").GetComponent<GameManager>().c;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pressDiff()
    {
        c.gameObject.SetActive(false);
        print("button " + a + " pressed");
        moveBack.startMoveBackground(difficulty);
        playerController.startPlayerMove();
        spawnerObs.startSpawnObstacles(difficulty);
        spawnerBonuses.startSpawnBonuses();
    }
}
