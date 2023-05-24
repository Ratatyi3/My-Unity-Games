using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public GameObject background;
    MoveBackground moveBack;

    MoveObstacles moveOb1;
    MoveObstacles moveOb2;

    // Start is called before the first frame update
    void Start()
    {
        moveBack = background.GetComponent<MoveBackground>();
        moveOb1 = gameObject.GetComponent<MoveObstacles>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            moveBack.stopBackground();
            moveOb1.stopMove();
        }
    }
}
