using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    Vector3 start_pos;
    float half_way;
    public bool start = false;
    public int difficulty = 10;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        start_pos = gameObject.transform.position;
        half_way = gameObject.GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (gameObject.transform.position.x < start_pos.x - half_way)
            {
                gameObject.transform.position = start_pos;
            }
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * difficulty);
        }
    }

    public void stopBackground()
    {
        start = false;
    }

    public void startBackground(int speed)
    {
        difficulty = speed;
        start = true;
    }
}
