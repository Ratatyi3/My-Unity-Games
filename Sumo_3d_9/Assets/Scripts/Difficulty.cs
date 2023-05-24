using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pressEasy()
    {
        gameManager.enemyForWin = 5;
        gameManager.mode = "easy";
        gameManager.startGame();
    }

    public void pressMedium()
    {
        gameManager.enemyForWin = 10;
        gameManager.mode = "medium";
        gameManager.startGame();
    }

    public void pressHard()
    {
        gameManager.enemyForWin = 11;
        gameManager.mode = "hard";
        gameManager.startGame();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
