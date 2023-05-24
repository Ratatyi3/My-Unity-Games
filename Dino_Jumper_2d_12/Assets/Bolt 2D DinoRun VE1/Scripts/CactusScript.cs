using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    Spawner spawner;
    int speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -8)
        {
            Destroy(gameObject);
        }
        speed = GameObject.Find("Spawner").GetComponent<Spawner>().speed;
        gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);

    }
}
