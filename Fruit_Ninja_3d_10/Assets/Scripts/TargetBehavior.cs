using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    float random_force;
    float random_torkue_x;
    float random_torkue_y;
    float random_torkue_z;
    Rigidbody myRb;
    GameObject game_man;
    public GameObject explosion;

    int Pizza;
    int Sandwich;
    int Meat;
    // Start is called before the first frame update
    void Start() // на старте мы задем силу взлета объекта (пицца или мясо) и вращения, и убираем между ними колизию.
   {  
        game_man = GameObject.Find("GameManager");
        myRb = gameObject.GetComponent<Rigidbody>();
        random_force = Random.Range(10, 15);
        random_torkue_x = Random.Range(-4, 4);
        random_torkue_y = Random.Range(-4, 4);
        random_torkue_z = Random.Range(-4, 4);
        myRb.AddForce(Vector3.up * random_force, ForceMode.Impulse);
        myRb.AddTorque(random_torkue_x, random_torkue_y, random_torkue_z, ForceMode.Impulse);

        
        Pizza = game_man.GetComponent<GameManager>().Pizza;
        Sandwich = game_man.GetComponent<GameManager>().Sandwich;
        Meat = game_man.GetComponent<GameManager>().Meat;

        GameObject[] pizzaArr = GameObject.FindGameObjectsWithTag("Pizza");
        if (pizzaArr.Length > 0)
        {
            for(int i = 0;i < pizzaArr.Length; i++)
            {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),pizzaArr[i].GetComponent<Collider>());
            }
        }
        GameObject[] sandwichArr = GameObject.FindGameObjectsWithTag("Sandwich");
        if (sandwichArr.Length > 0)
        {
            for (int i = 0; i < sandwichArr.Length; i++)
            {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), sandwichArr[i].GetComponent<Collider>());
            }
        }
        GameObject[] meatArr = GameObject.FindGameObjectsWithTag("Meat");
        if (meatArr.Length > 0)
        {
            for (int i = 0; i < meatArr.Length; i++)
            {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), meatArr[i].GetComponent<Collider>());
            }
        }

        GameObject bonusX2 = GameObject.FindGameObjectWithTag("BonusX2");
        if(bonusX2 != null)
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), bonusX2.GetComponent<Collider>());

        GameObject DestroyAll = GameObject.FindGameObjectWithTag("DestroyAll");
        if (DestroyAll != null)
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), DestroyAll.GetComponent<Collider>());
        GameObject slowDown = GameObject.FindGameObjectWithTag("SlowDown");
        if (slowDown != null)
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), slowDown.GetComponent<Collider>());
        GameObject StopSpawnBad = GameObject.FindGameObjectWithTag("StopSpawnBad");
        if (StopSpawnBad != null)
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), StopSpawnBad.GetComponent<Collider>());



        if (gameObject.CompareTag("Bad"))
        {
            GameObject[] badArr = GameObject.FindGameObjectsWithTag("Bad");
            if (badArr.Length > 0)
            {
                for (int i = 0; i < badArr.Length; i++)
                {
                    Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), badArr[i].GetComponent<Collider>());
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    { //  мы удаляем объекты которые упали вниз и вызываем гейм овер если упал положительный объект.
        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad") && !gameObject.CompareTag("secondWinCondition") && game_man.GetComponent<GameManager>().activeGame)
            {
                game_man.GetComponent<GameManager>().gameOver();
            }
        }
    }

    private void OnMouseOver()
    {
        if (game_man.GetComponent<GameManager>().activeGame)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            if (gameObject.CompareTag("Bad"))
            { 
                game_man.GetComponent<GameManager>().audioExplosion.Play();
                game_man.GetComponent<GameManager>().gameOver();
            }
            else if (gameObject.CompareTag("Pizza"))
            {
                game_man.GetComponent<GameManager>().score += Pizza;
            }
            else if (gameObject.CompareTag("Sandwich"))
            {
                game_man.GetComponent<GameManager>().score += Sandwich;
            }
            else if (gameObject.CompareTag("Meat"))
            {
                game_man.GetComponent<GameManager>().score += Meat;
            }
            else if (gameObject.CompareTag("BonusX2"))
            {
                game_man.GetComponent<GameManager>().startTimer();
            }
            else if (gameObject.CompareTag("DestroyAll"))
            {
                GameManager a = game_man.GetComponent<GameManager>();
                GameObject[] pizzaArr = GameObject.FindGameObjectsWithTag("Pizza");
                if (pizzaArr.Length > 0)
                {
                    for (int i = 0; i < pizzaArr.Length; i++)
                    {
                        Destroy(pizzaArr[i]);
                        a.score += Pizza;
                    }
                }
                GameObject[] sandwichArr = GameObject.FindGameObjectsWithTag("Sandwich");
                if (sandwichArr.Length > 0)
                {
                    for (int i = 0; i < sandwichArr.Length; i++)
                    {
                        Destroy(sandwichArr[i]);
                        a.score += Sandwich;
                    }
                }
                GameObject[] meatArr = GameObject.FindGameObjectsWithTag("Meat");
                if (meatArr.Length > 0)
                {
                    for (int i = 0; i < meatArr.Length; i++)
                    {
                        Destroy(meatArr[i]);
                        a.score += Meat;
                    }
                }
            }
            else if (gameObject.CompareTag("SlowDown"))
            {
                game_man.GetComponent<GameManager>().slowDownBonus();
            }
            else if (gameObject.CompareTag("StopSpawnBad"))
            {
                game_man.GetComponent<GameManager>().stopSpawnBadBonus();
            }
            else if (gameObject.CompareTag("secondWinCondition"))
            {
                game_man.GetComponent<GameManager>().carrotsForSecondWinCondition += 1;
            }
            Destroy(gameObject);
        }
    }
}
