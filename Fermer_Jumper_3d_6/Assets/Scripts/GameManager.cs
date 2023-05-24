using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas c;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public Button restartButton;

    public GameObject spawner;
    MoveBackground backgroundScript;
    PlayerController pl_contr;
    // Start is called before the first frame update
    void Start()
    {
        backgroundScript = GameObject.Find("Background").GetComponent<MoveBackground>();
        pl_contr = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + score);
        if(score >= 100)
        {
            win();
        }
    }

    public void win()
    {
        Destroy(spawner);
        backgroundScript.stopBackground();
        pl_contr.stopPlayerMove();
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
        restartButton.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
    }

    public void lose()
    {
        Destroy(spawner);
        backgroundScript.stopBackground();
        pl_contr.stopPlayerMove();
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
        restartButton.gameObject.SetActive(true);
        loseText.gameObject.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
