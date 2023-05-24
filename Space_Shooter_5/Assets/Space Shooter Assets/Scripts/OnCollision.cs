using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    int countAsteroid;
    public int bulletsForAsteroid = 3;
    int countEnemy;
    public int bulletsForEnemy = 1;
    CanvasManager canvasManager;
    Spawner spawnerScript;
    int scoreEnemy = 1;
    int scoreAsteroid = 10;

    public GameObject explosion;

    void Start()
    {
        countAsteroid = 0;
        countEnemy = 0;

        canvasManager = GameObject.Find("GameManager").GetComponent<CanvasManager>();
        spawnerScript = GameObject.Find("SpawnerObject").GetComponent<Spawner>();

        scoreEnemy = canvasManager.scoreEnemy;
        scoreAsteroid = canvasManager.scoreAsteroid;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setDiffEnemy(int i)
    {
        bulletsForEnemy = i;
        GameObject.Find("SpawnerObject").GetComponent<Spawner>().startSpawn();
        CanvasManager gameMan = GameObject.Find("GameManager").GetComponent<CanvasManager>();
        gameMan.canvas.gameObject.SetActive(false);
        gameMan.textScore.gameObject.SetActive(true);
        GameObject.Find("player1").GetComponent<MoveShip>().startMoveShip();
        gameObject.GetComponent<MoveForward>().forwardSpeed = 7;

        if(i == 1)
            gameMan.easyMode = true;
        if(i == 2)
            GameObject.Find("GameManager").GetComponent<CanvasManager>().hardMode = true;
    }
    public void setDiffAstr(int i)
    {
        bulletsForAsteroid = i;
    }

    public void setHardMode()
    {
        GameObject.Find("SpawnerObject").GetComponent<Spawner>().setHard();
        gameObject.GetComponent<MoveForward>().forwardSpeed = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (gameObject.CompareTag("Mars") || gameObject.CompareTag("Earth") || gameObject.CompareTag("Moon") || gameObject.CompareTag("Venus")))
        {
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            canvasManager.lose = true;
        }

        if (gameObject.CompareTag("Asteroid"))
        {
            countAsteroid = countAsteroid + 1;
            Destroy(other.gameObject);
            if (countAsteroid >= bulletsForAsteroid)
            {
                Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
                Destroy(gameObject);
                canvasManager.score = canvasManager.score + scoreAsteroid;
            }
        }
        if (gameObject.CompareTag("Enemy"))
        {
            countEnemy = countEnemy + 1;
            Destroy(other.gameObject);
            if (countEnemy >= bulletsForEnemy)
            {
                Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
                Destroy(gameObject);
                canvasManager.score = canvasManager.score + scoreEnemy;
            }
        }

        if (gameObject.CompareTag("Mars"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
            canvasManager.startTimer("x2");
            print("x2");
        }
        else if (gameObject.CompareTag("Earth"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
            canvasManager.startTimer("multiplyBullet");
            print("MB");
        }
        else if (gameObject.CompareTag("Moon"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
            canvasManager.startTimer("allDestroy");
            print("AD");
        }
        else if (gameObject.CompareTag("Venus"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
            canvasManager.startTimer("plus20Score");
            print("P20");
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
            canvasManager.lose = true;
        }
        else if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Asteroid"))
        {
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            canvasManager.lose = true;
        }
    }
}
