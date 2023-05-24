using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    public int speed;
    public static bool a;
    bool startGame;
    GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        a = true;
        startGame = true;
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (transform.position.x < -10)
            {
                gameManagerScript.score += 5;
                Destroy(gameObject);
            }
            else if (a == true)
            {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
    }

    public void stopMove(){
        a = false;
    }
}
