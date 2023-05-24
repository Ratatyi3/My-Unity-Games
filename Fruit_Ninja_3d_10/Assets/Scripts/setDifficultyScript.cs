using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDifficultyScript : MonoBehaviour
{
    GameManager game_man_script;
    // Start is called before the first frame update
    void Start()
    {
        game_man_script = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEasyMode() // устанавливаем сложность, скрываем меню игры и запускаем спавн объектов.
    {
        game_man_script.targetsSpawnSpeed = 1.0f;
        game_man_script.badSpawnSpeed = 2.0f;
        game_man_script.winScore = 200;
        game_man_script.difficultyMode.gameObject.SetActive(false);
        game_man_script.activeGame = true;
        game_man_script.startSpawn();
    }

    public void setMediumMode() 
    {
        game_man_script.targetsSpawnSpeed = 0.8f;
        game_man_script.badSpawnSpeed = 1.0f;
        game_man_script.winScore = 250;
        game_man_script.difficultyMode.gameObject.SetActive(false);
        game_man_script.activeGame = true;
        game_man_script.startSpawn();
    }

    public void setHardMode()
    {
        game_man_script.targetsSpawnSpeed = 0.5f;
        game_man_script.badSpawnSpeed = 1.0f;
        game_man_script.winScore = 300;
        game_man_script.difficultyMode.gameObject.SetActive(false);
        game_man_script.activeGame = true;
        game_man_script.startSpawn();
    }
}
