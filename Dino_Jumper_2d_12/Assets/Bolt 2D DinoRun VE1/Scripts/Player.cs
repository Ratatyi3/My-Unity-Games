using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool startMove;
    Rigidbody2D player_rb;

    public Canvas canvas;
    public TextMeshProUGUI win;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI distance;
    public float dist;
    public float winDist;
    public Button restart;

    Spawner spawner;
    private MoveBackground moveBackgroundSky;
    private MoveBackground moveBackgroundCloud;
    private MoveBackground moveBackgroundRock;
    private MoveBackground moveBackgroundGround;

    public int curSpeed;
    int jump_force;
    public ParticleSystem parttic;
    // Start is called before the first frame update
    void Start()
    {
        dist = 0;
        winDist = 20;
        startMove = false;
        player_rb = gameObject.GetComponent<Rigidbody2D>();
        jump_force = 6;

        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        moveBackgroundSky = GameObject.Find("Sky Set").GetComponent<MoveBackground>();
        moveBackgroundCloud = GameObject.Find("Cloud Set").GetComponent<MoveBackground>();
        moveBackgroundRock = GameObject.Find("Back Set").GetComponent<MoveBackground>();
        moveBackgroundGround = GameObject.Find("Ground Set").GetComponent<MoveBackground>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            dist += 0.01f;
            distance.SetText("Distance: " + dist);
            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 1.25f)
            {
                player_rb.AddForce(-Physics.gravity.normalized * jump_force, ForceMode2D.Impulse);
            }
        }
        if (dist >= winDist)
        {
            stopGame();
            winM();
        }
    }

    private IEnumerator StartTimer(float time)
    {
        yield return new WaitForSeconds(time);
        spawner.stopSpawn();
        spawner.startSpawn(curSpeed);
        moveBackgroundSky.startBackground(curSpeed);
        moveBackgroundCloud.startBackground(curSpeed);
        moveBackgroundRock.startBackground(curSpeed);
        moveBackgroundGround.startBackground(curSpeed);
        jump_force = 6;
    }


    public void startGame()
    {
        canvas.gameObject.SetActive(false);
        startMove = true;
    }
    public void stopGame()
    {
        startMove = false;
        spawner.stopSpawn();
        moveBackgroundSky.stopBackground();
        moveBackgroundCloud.stopBackground();
        moveBackgroundRock.stopBackground();
        moveBackgroundGround.stopBackground();
        GameObject[] kaktusLeft = GameObject.FindGameObjectsWithTag("Kaktus");
        for (int i = 0; i < kaktusLeft.Length; i++)
        {
            Destroy(kaktusLeft[i]);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kaktus"))
        {
            Instantiate(parttic, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(collision.gameObject);
            stopGame();
            loseM();
        }
        if (collision.gameObject.CompareTag("LoseCloud"))
        {
            Destroy(gameObject);
            stopGame();
            loseM();
        }
        else if (collision.gameObject.CompareTag("DistanceBonus"))
        {
            print("dist");
            Destroy(collision.gameObject);
            dist += 10;
        }
        else if (collision.gameObject.CompareTag("SpeedDown"))
        {
            curSpeed = spawner.speed;
            print("speedDown");
            Destroy(collision.gameObject);
            spawner.stopSpawn();
            spawner.startSpawn(curSpeed - 2);
            moveBackgroundSky.startBackground(curSpeed - 2);
            moveBackgroundCloud.startBackground(curSpeed - 2);
            moveBackgroundRock.startBackground(curSpeed - 2);
            moveBackgroundGround.startBackground(curSpeed - 2);

            StartCoroutine(StartTimer(10f));
        }
        else if (collision.gameObject.CompareTag("SpeedUp"))
        {
            curSpeed = spawner.speed;
            print("speedUp");
            Destroy(collision.gameObject);
            spawner.stopSpawn();
            spawner.startSpawn(curSpeed + 3);
            moveBackgroundSky.startBackground(curSpeed + 2);
            moveBackgroundCloud.startBackground(curSpeed + 2);
            moveBackgroundRock.startBackground(curSpeed + 2);
            moveBackgroundGround.startBackground(curSpeed + 2);

            StartCoroutine(StartTimer(10f));
        }
        else if (collision.gameObject.CompareTag("HighJump"))
        {
            print("highJump");
            Destroy(collision.gameObject);
            jump_force = 8;
            StartCoroutine(StartTimer(10f));
        }
    }

    public void loseM()
    {
        lose.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }
    public void winM()
    {
        win.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }

    public void res()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
