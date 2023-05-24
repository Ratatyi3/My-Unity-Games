using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DufficultyLevel : MonoBehaviour
{
    private Spawner spawner;
    private Player player;
    private MoveBackground moveBackgroundSky;
    private MoveBackground moveBackgroundCloud;
    private MoveBackground moveBackgroundRock;
    private MoveBackground moveBackgroundGround;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        player = GameObject.Find("Player").GetComponent<Player>();
        moveBackgroundSky = GameObject.Find("Sky Set").GetComponent<MoveBackground>();
        moveBackgroundCloud = GameObject.Find("Cloud Set").GetComponent<MoveBackground>();
        moveBackgroundRock = GameObject.Find("Back Set").GetComponent<MoveBackground>();
        moveBackgroundGround = GameObject.Find("Ground Set").GetComponent<MoveBackground>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressMode(int dif)
    {
        if (dif == 5)
        {
            player.winDist = 20;
        }
        else
            player.winDist = 30;
        spawner.startSpawn(dif);
        player.startGame();
        moveBackgroundSky.startBackground(dif);
        moveBackgroundCloud.startBackground(dif);
        moveBackgroundRock.startBackground(dif);
        moveBackgroundGround.startBackground(dif);

    }
}
