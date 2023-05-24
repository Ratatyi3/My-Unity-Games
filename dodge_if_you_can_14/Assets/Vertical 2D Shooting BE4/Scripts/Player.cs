using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPlaying;
    float horizont;
    int speed = 5;

    public float enemySpeed = 5;

    public GameObject bullet;
    private bool bossSpawn;
    private bool shootAbility;

    public ParticleSystem destroyShipEffect;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        shootAbility = false;
        bossSpawn = true;
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= -3 && gameObject.transform.position.x <= 3)
        {
            if (isPlaying)
            {
                horizont = Input.GetAxis("Horizontal");
                gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime * horizont;
            }
        }
        else if (gameObject.transform.position.x < -3)
        {
            gameObject.transform.position = new Vector3(-3, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x > 3)
        {
            gameObject.transform.position = new Vector3(3, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (enemySpeed == 15 && GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>()._timeLeft <= 35 && bossSpawn)
        {
            GameObject.Find("Spawn").GetComponent<SpawnEnemy>().notSpawn();
            GameObject.Find("Spawn").GetComponent<SpawnEnemy>().notSpawnBonus();
            GameObject.Find("Spawn").GetComponent<SpawnEnemy>().spawnBoss();
            bossSpawn = false;
            shootAbility = true;
        }

        if (shootAbility && Input.GetKeyDown(KeyCode.Space))
        {
            spawnBullet();
        }
    }


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("enemy"))
        {
            isPlaying = false;
            GameObject.Find("Spawn").GetComponent<SpawnEnemy>().notSpawn();
            GameObject.Find("Spawn").GetComponent<SpawnEnemy>().notSpawnBonus();
            GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>().showLose();
            GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>()._timerOn = false;
            Instantiate(destroyShipEffect, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("boss"))
        {
            isPlaying = false;
            GameObject.Find("Spawn").GetComponent<SpawnEnemy>().notSpawn();
            GameObject.Find("Spawn").GetComponent<SpawnEnemy>().notSpawnBonus();
            GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>().showLose();
            GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>()._timerOn = false;
            Instantiate(destroyShipEffect, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
        else if (collider.gameObject.CompareTag("lessTime"))
        {
            GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>()._timeLeft -= 5;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("boom"))
        {
            GameObject[] en = GameObject.FindGameObjectsWithTag("enemy");
            for (int i = 0; i < en.Length; i++)
            {
                Destroy(en[i]);
            }
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("shipMovePower"))
        {
            speed = speed + 3;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("shoot"))
        {
            shootAbility = true;
            StartCoroutine(shootOn10Sec(10f));
            Destroy(collider.gameObject);
        }
    }

    public void spawnBullet()
    {
        Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
    }

    private IEnumerator shootOn10Sec(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        shootAbility = false;
    }
}
