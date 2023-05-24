using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    Vector3 start_pos;
    float half_way;
    public static bool a;
    public bool start = false;
    public int difficulty = 10;
    // Start is called before the first frame update
    void Start()
    {
        
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
            else if (a == true)
            {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime * difficulty);
            }
        }
    }

    public void stopBackground(){
        a = false;
    }

    public void startMoveBackground(int diff)
    {
        difficulty = diff;
        a = true;
        start_pos = gameObject.transform.position;
        half_way = gameObject.GetComponent<BoxCollider>().size.x / 2;
        start = true;
    }
}
