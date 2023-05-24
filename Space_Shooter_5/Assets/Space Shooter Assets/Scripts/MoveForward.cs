using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float forwardSpeed;
    CanvasManager gameManScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManScript = GameObject.Find("GameManager").GetComponent<CanvasManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 9 || transform.position.x < -9)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Enemy")) {
                gameManScript.score = gameManScript.score - 10;
            }
            if (gameObject.CompareTag("Asteroid"))
            {
                gameManScript.score = gameManScript.score - 100;
            }
        }
        transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);
    }
}
