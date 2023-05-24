using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool activeGame = false;
    public GameObject[] specialElements = new GameObject[4];
    public GameObject[] targets = new GameObject[3];
    public GameObject[] badTargets = new GameObject[2];
    public GameObject secondWinCondition;
    public int carrotsForSecondWinCondition = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public Canvas difficultyMode;
    public Button restartButton;
    public int score;
    public int winScore = 200;

    public int Pizza = 1;
    public int Sandwich = 3;
    public int Meat = 5;
    public float targetsSpawnSpeed = 1.0f;
    public float badSpawnSpeed = 2.0f;

    public int everyHundread = 0;
    public GameObject[] particleEffects = new GameObject[6];
    public AudioSource audioExplosion;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    { // обновляем количество очков на экране, каждые 50 очков спавнится второе условие победы и салют. 
        scoreText.SetText("Score: " + score);

        if ((score - everyHundread) > 50)
        {
            carrotsForSecondWinCondition = 0;
            for (int i = 0; i < particleEffects.Length; i++)
            {
                Instantiate(particleEffects[i], new Vector3(Random.Range(-4, 4), Random.Range(0, 8), 0), Quaternion.identity);
            }
            everyHundread += 50;
            spawnSecondWinCondition();
        }
        // если набронно необходимое количество очков срабатывает функция победы.
        if(score >= winScore)
        {
            winGame();
        }
        if(carrotsForSecondWinCondition >= 4)
        {
            winGame();
        }
    }

    public void startSpawn()
    {
        InvokeRepeating("Spawn", 0, targetsSpawnSpeed);
        InvokeRepeating("SpawnBad", 0, badSpawnSpeed);
        InvokeRepeating("SpawnSpecial", 10, 10);
    }

    public void stopSpawn()
    {
        CancelInvoke();
    }

    public void slowDownBonus()
    {
        CancelInvoke();
        targetsSpawnSpeed = targetsSpawnSpeed + 0.5f;
        badSpawnSpeed = badSpawnSpeed + 0.5f;
        startSpawn();
    }

    public void stopSpawnBadBonus()
    {
        CancelInvoke("SpawnBad");
        StartCoroutine(Co_WaitForSeconds2(10f));
    }

    private IEnumerator Co_WaitForSeconds(float value)
    {
        yield return new WaitForSeconds(value);
        Pizza = 1;
        Sandwich = 3;
        Meat = 5;
    }

    private IEnumerator Co_WaitForSeconds2(float value)
    {
        yield return new WaitForSeconds(value);
        InvokeRepeating("SpawnBad", 0, badSpawnSpeed);
    }

    public void startTimer()
    {
        Pizza = Pizza * 2;
        Sandwich = Sandwich * 2;
        Meat = Meat * 2;
        StartCoroutine(Co_WaitForSeconds(10f));
    }

    void Spawn()
    {
        Instantiate(targets[Random.Range(0, 3)], new Vector3(Random.Range(-4f, 4f), 0, 0), Quaternion.identity);
    }

    void SpawnBad()
    {
        Instantiate(badTargets[Random.Range(0, 2)], new Vector3(Random.Range(-4f, 4f), 0, 0), Quaternion.identity);
    }

    void SpawnSpecial()
    {
        Instantiate(specialElements[Random.Range(0,4)], new Vector3(Random.Range(-4f, 4f), 0, 0), Quaternion.identity);
    }

    void spawnSecondWinCondition()
    {
        for(int i = 0;i< 4; i++)
        {
            Instantiate(secondWinCondition, new Vector3(Random.Range(-4f, 4f), 0, 0), Quaternion.identity);
        }
    }

    public void gameOver()
    {
        activeGame = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        stopSpawn();
    }

    public void winGame()
    {
        activeGame = false;
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        stopSpawn();
    }

    public void restart()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
