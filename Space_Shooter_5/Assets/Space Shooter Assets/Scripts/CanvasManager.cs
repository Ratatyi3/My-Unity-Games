using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public Canvas canvas;
    public int score = 0;
    public TextMeshProUGUI textScore;
    Spawner spawnerScript;
    MoveShip moveShipScript;
    int countScore = 20;

    public int scoreEnemy = 1;
    public int scoreAsteroid = 10;

    int winScore = 100;
    public TextMeshProUGUI winText;
    public Button restart;
    public TextMeshProUGUI loseText;
    public bool lose = false;
    public bool hardMode = false;
    public bool easyMode = false;
         
    bool bonusX2 = true;
    bool bonusMultiplyBullet = true;
    bool bonusOneShot = true;
    bool bonus100Score = true;

    public GameObject enemyExplosion;
    public GameObject asteroidExplosion;

    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = GameObject.Find("SpawnerObject").GetComponent<Spawner>();
        moveShipScript = GameObject.Find("player1").GetComponent<MoveShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > countScore)
        {
            spawnerScript.SpawnBonuse();
            countScore += 20;
        }
        if(score < 0 || lose)
        {
            stopLoseGame();
            score = 0;
        }
        textScore.SetText("Score: " + score);

        if(score >= winScore && easyMode)
        {
            stopWinGame();
        }
        if(score >= 200 && hardMode)
        {
            stopWinGame();
        }
    }

    private void stopWinGame()
    {
        moveShipScript.stopMoveShip();
        spawnerScript.stopSpawn();
        winText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        GameObject e = GameObject.FindGameObjectWithTag("Player");
        Destroy(e);
    }

    private void stopLoseGame()
    {
        moveShipScript.stopMoveShip();
        spawnerScript.stopSpawn();
        loseText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        GameObject e = GameObject.FindGameObjectWithTag("Player");
        Destroy(e);
    }

    private IEnumerator Co_WaitForSeconds(float value,string bonus)
    {
        yield return new WaitForSeconds(value);
        if (bonus == "x2")
        {
            bonusX2 = false;
            scoreEnemy = 1;
            scoreAsteroid = 10;
        } 
        else if(bonus == "multiplyBullet")
        {
            bonusMultiplyBullet = false;
            moveShipScript.multiply = false;
        }
        else if(bonus == "oneShot")
        {
            bonusOneShot = false;
        }
        else
        {
            bonus100Score = false;
        }
    }

    public void startTimer(string bonus)
    {
        if (bonus == "x2")
        {
            scoreEnemy = scoreEnemy * 2;
            scoreAsteroid = scoreAsteroid * 2;
            StartCoroutine(Co_WaitForSeconds(10f,bonus));
        }
        else if(bonus == "multiplyBullet")
        {
            moveShipScript.multiply = true;
            StartCoroutine(Co_WaitForSeconds(10f, bonus));
        }
        else if (bonus == "allDestroy")
        {
            GameObject[] cloneAstrs = GameObject.FindGameObjectsWithTag("Asteroid");
            GameObject[] cloneEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0;i < cloneAstrs.Length; i++)
            {
                Destroy(cloneAstrs[i].gameObject);
            }
            for (int i = 0; i < cloneEnemies.Length; i++)
            {
                Destroy(cloneEnemies[i].gameObject);
            }

        }
        else if(bonus == "plus20Score")
        {
            score = score + 20;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
