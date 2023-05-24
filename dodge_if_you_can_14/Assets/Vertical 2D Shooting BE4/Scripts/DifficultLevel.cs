using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultLevel : MonoBehaviour
{
    Player Player;
    SpawnEnemy spawnEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        spawnEnemy = GameObject.Find("Spawn").GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void easy()
    {
        Player.enemySpeed = 5;
        GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>().hideTitleInterface();
        spawnEnemy.Spawn();
        GameObject.Find("Player").GetComponent<Player>().isPlaying = true;
    }

    public void medium()
    {
        Player.enemySpeed = 10;
        GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>().hideTitleInterface();
        spawnEnemy.Spawn();
        GameObject.Find("Player").GetComponent<Player>().isPlaying = true;
    }

    public void hard()
    {
        Player.enemySpeed = 15;
        GameObject.Find("InterfaceManager").GetComponent<InterfaceManager>().hideTitleInterface();
        spawnEnemy.Spawn();
        GameObject.Find("Player").GetComponent<Player>().isPlaying = true;
    }

    public void rest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
