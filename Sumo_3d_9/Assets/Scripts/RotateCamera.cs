using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float horInp;
    private float speed = 25;
    public bool startGame;
    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            horInp = Input.GetAxis("Horizontal");
            gameObject.transform.Rotate(Vector3.up, horInp * speed * Time.deltaTime);
        }
    }
}
