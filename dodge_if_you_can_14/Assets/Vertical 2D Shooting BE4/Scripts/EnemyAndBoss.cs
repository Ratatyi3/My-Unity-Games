using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndBoss : MonoBehaviour
{
    public float enemySpeed = 5;
    public float bossSpeed;
    public int bossLives;
    // Start is called before the first frame update
    void Start()
    {
        bossLives = 20;
        if(GameObject.Find("Player") != null)
            enemySpeed = GameObject.Find("Player").GetComponent<Player>().enemySpeed;
        bossSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("enemy"))
        {
            if (transform.position.y < -12)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
        }
        else
        {
            if (transform.position.y < -12)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector2.down * bossSpeed * Time.deltaTime);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("enemy") && other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
         else if (gameObject.CompareTag("boss") && other.gameObject.CompareTag("bullet"))
        {
            if (bossLives <= 0)
            {
                Destroy(gameObject);
                GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>().showFinish();
                GameObject.Find("Player").GetComponent<Player>().isPlaying = false;
                GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>()._timerOn = false;
            }
            Destroy(other.gameObject);
            bossLives -= 1;
        }
    }
}
