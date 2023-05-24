using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI win;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI score;
    public int scoreNum;
    public int enemyForWin = 5;
    public int timeForWin = 60;
    public Button restart;
    public Canvas menuCanvas;

    PlayerController playerController;
    RotateCamera rotateCamera;
    Spawner spawner;
    public string mode;

    private float time = 60f;
    public TextMeshProUGUI timeText;
    public float timeLeft = 0f;
    bool timerWork = true;

    // Start is called before the first frame update
    void Start()
    { 
        scoreNum = 0;
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        rotateCamera = GameObject.Find("FocalPoint").GetComponent<RotateCamera>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        timeLeft = time;
    }

    // Update is called once per frame
    void Update()
    {
        score.SetText("Score: " + scoreNum);
        if(scoreNum >= enemyForWin)
        {
            winGame();
        }
    }

    private IEnumerator StartTimer()
    {
        while(timeLeft > 0)
        {
            if (timerWork)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            yield return null;
        }
    }

    private void UpdateTimeText()
    {
        if (timeLeft < 0)
        {
            winGame();
            timeLeft = 0;
        }
        timeText.SetText("left for win:" + timeLeft);
    }

    public void startGame()
    {
        StartCoroutine(StartTimer());
        rotateCamera.startGame = true;
        playerController.startGame = true;

        if (mode.Equals("easy"))
        {
            spawner.easySpawn = true;
            spawner.countEnemies = 1;
            spawner.spawnEnemy();
            spawner.startGame = true;
        }
        else if (mode.Equals("medium"))
        {
            spawner.mediumSpawn = true;
            spawner.countEnemies = 2;
            spawner.spawnEnemy();
            spawner.startGame = true;
        }
        else if (mode.Equals("hard"))
        {
            spawner.hardSpawn = true;
            spawner.countEnemies = 2;
            spawner.spawnEnemy();
            spawner.startGame = true;
        }

        menuCanvas.gameObject.SetActive(false);
    }

    public void winGame()
    {
        spawner.startGame = false;
        rotateCamera.startGame = false;
        playerController.startGame = false;
        win.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        timerWork = false;
    }

    public void loseGame()
    {
        spawner.startGame = false;
        rotateCamera.startGame = false;
        playerController.startGame = false;
        lose.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        timerWork = false;
    }
}
