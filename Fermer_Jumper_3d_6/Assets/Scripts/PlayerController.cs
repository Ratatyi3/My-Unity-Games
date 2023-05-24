using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb_player;
    private Animator playerAn;
    bool start = false;
    int jumpTimes = 0;
    GameManager game_manScript;
    bool jetpackBonus = false;
    public ParticleSystem jetpackEffect;
    public ParticleSystem crashEffect;
    ParticleSystem cloneJet;
    // Start is called before the first frame update
    void Start()
    {
        game_manScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (jetpackBonus)
            {
                if (transform.position.y >= 6)
                {
                    transform.position = new Vector3(transform.position.x,6,transform.position.z);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    rb_player.AddForce(-Physics.gravity.normalized * 4, ForceMode.Impulse);
                    playerAn.SetTrigger("Jump_trig");

                }
                cloneJet.transform.position = transform.position;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.25f)
                {
                    rb_player.AddForce(-Physics.gravity.normalized * 8, ForceMode.Impulse);
                    playerAn.SetTrigger("Jump_trig");
                    jumpTimes = 1;
                }
                if (Input.GetKeyDown(KeyCode.Space) && transform.position.y > 0.5f && jumpTimes == 1)
                {
                    rb_player.AddForce(-Physics.gravity.normalized * 8, ForceMode.Impulse);
                    jumpTimes = 2;
                }
            }
        }

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
    }


    private IEnumerator Co_WaitForSeconds(float value)
    {
        yield return new WaitForSeconds(value);
        jetpackBonus = false;
        cloneJet.Stop();
    }


    private void OnCollisionEnter(Collision collision){
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "Obstacle"){
            ParticleSystem clone = Instantiate(crashEffect, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
            clone.Play();
            playerAn.SetTrigger("Death_b");
            playerAn.SetInteger("DeathType_int",1);
            game_manScript.lose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "winBonus")
        {
            Destroy(other.gameObject);
            game_manScript.win();
        }
        else if (other.gameObject.tag == "loseBonus")
        {
            Destroy(other.gameObject);
            game_manScript.lose();
            playerAn.SetTrigger("Death_b");
            playerAn.SetInteger("DeathType_int", 1);
        }
        else if (other.gameObject.tag == "plus10Score")
        {
            Destroy(other.gameObject);
            game_manScript.score += 10;
        }
        else if (other.gameObject.tag == "jetpack")
        {
            Destroy(other.gameObject);
            jetpackBonus = true;
            cloneJet = Instantiate(jetpackEffect, transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            StartCoroutine(Co_WaitForSeconds(10f));
        }
    }

    public void startPlayerMove()
    {
        rb_player = gameObject.GetComponent<Rigidbody>();
        playerAn = gameObject.GetComponent<Animator>();
        start = true;
    }
    public void stopPlayerMove()
    {
        start = false;
    }
}
