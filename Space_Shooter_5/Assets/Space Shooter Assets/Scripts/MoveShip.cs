using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public GameObject projectile;
    public float speedFarmer;
    public float input;
    private bool startMove = false;
    public bool multiply = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            if (System.MathF.Abs(transform.position.y) > 4)
            {
                if (transform.position.y < 0)
                    transform.position = new Vector2(transform.position.x, -4);
                else
                    transform.position = new Vector2(transform.position.x, 4);
            }
            else
            {
                input = Input.GetAxis("Vertical");
                transform.position += new Vector3(0, speedFarmer, 0)
                    * Time.deltaTime * input;
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectile, transform.position, transform.rotation);
                if (multiply)
                {
                    Instantiate(projectile, transform.position, Quaternion.Euler(transform.rotation.x,transform.rotation.y,transform.rotation.z + 30));
                    Instantiate(projectile, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 30));
                }
            }
        }
    }

    public void startMoveShip()
    {
        startMove = true;
    }
    public void stopMoveShip()
    {
        startMove = false;
    }
}
