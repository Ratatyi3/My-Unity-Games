using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float base_force = 20;
    public GameObject focalPoint;
    public Rigidbody playerRb;
    public float verInp;
    public bool startGame;
    public bool score10 = false;
    public bool impulse = false;
    public bool jump = false;
    public GameObject particleEffect;

    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
        playerRb = gameObject.GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (gameObject.transform.position.y <= -5)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().loseGame();
            }
            verInp = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * base_force * verInp);
            
            if (jump && Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.25f)
            {
                playerRb.AddForce(-Physics.gravity.normalized * 50, ForceMode.Impulse);
            }
        }
    }

    private IEnumerator Co_WaitForSeconds(float value)
    {
        yield return new WaitForSeconds(value);
        jump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Impulse"))
        {
            impulse = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("TimeMinus10"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().timeLeft -= 10;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("LoseBonus"))
        {
            Destroy(other.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().loseGame();
        }
        if (other.gameObject.CompareTag("JumpBonus"))
        {
            Destroy(other.gameObject);
            jump = true;
            StartCoroutine(Co_WaitForSeconds(10f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && impulse)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = collision.gameObject.transform.position - transform.position;
            enemyRB.AddForce(away * 50, ForceMode.Impulse);
            impulse = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particleEffect, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
}
