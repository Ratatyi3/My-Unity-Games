using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI finish;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI timeLeftForFinish;
    public Button easy;
    public Button medium;
    public Button hard;
    public Button restart;


    private float time;
    private string timerText;

    public float _timeLeft = 0f;
    public bool _timerOn = false;

    public bool bossSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = 60;

        finish.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = time;
                _timerOn = false;
                showFinish();
                GameObject.Find("Player").GetComponent<Player>().isPlaying = false;
                GameObject.Find("Spawn").GetComponent<SpawnEnemy>().notSpawn();
            }
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText = string.Format("{0:00} : {1:00}", minutes, seconds);
        timeLeftForFinish.SetText("Time For Finish: " + timerText);
    }

    public void hideTitleInterface()
    {
        _timerOn = true;
        title.gameObject.SetActive(false);
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
    }

    public void showFinish()
    {
        finish.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }

    public void showLose()
    {
        lose.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }
}
