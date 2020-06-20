using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Allows any script to call the Game Manager.
    public int score; //Placeholder int to be tweaked by other objects such as ships.
    public int lives = 3; //Allows the designer to set a number of respawns the player has before loss.
    public float spawnDistance; //Allows the designer to set a random distance from the spawner.
    public float respawnTime; //Allows the designer to set an amount of time before the player respawns.
    [HideInInspector] public float timer; //Holds the amount of the the game has been playing.
    public GameObject player; //Allows the designer to assign the player object in inspector.
    public GameObject music; //Allows the designer to attach a music gameobject to this.
    public GameObject playerPrefab; //Attaches the player prefab to be respawned on death.
    public List<GameObject> enemyList; //This list is attached to ship objects that will fill this list.
    public List<GameObject> enemyPrefabList; //Allows the designer to fill in which enemies will be spawned in the inspector.
    public List<Transform> spawnPointList; //This is a list attached to specified spawn points to fill with ships.
    public Text scoreTracker; //Sets a canvas's text object to a variable that can be changed by the script.

    
    private void Awake()
    {
        //Sets this GameManger to a Singleton.
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            enemyList = new List<GameObject>();
        } else
        {
            Destroy(this.gameObject);
            Debug.LogError("[GameManager] Attempted to create a second Game Manager: " + this.gameObject.name);
        }
    }

    //Creates a destroyable gameobject with music attached.
    void PlayMusic()
    {
        Instantiate(music);
    }

    void SpawnEnemy()
    {

        GameObject enemyToSpawn = enemyPrefabList[Random.Range(0, enemyPrefabList.Count)]; 

        //Assigns the Spawn Point to any random spawnpoint assigned in the inspector.
        Transform spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];

        //Picks a point within distance of spawn point to spawn at.
        Vector3 randomVector = Random.insideUnitCircle;
        Vector3 newPosition = spawnPoint.position + (randomVector * spawnDistance);

        //Ensures the random location spawned is not off the Z axis/off the game plane.
        Instantiate(enemyToSpawn, new Vector3(newPosition.x, newPosition.y, 0), Quaternion.identity);
    }

    private void Update()
    {
        scoreTracker.text = score.ToString(); //Sets the canvas text element to the player's score.

        //Holds the time as a variable that can be reset on death.
        timer += Time.deltaTime;

        //Spawns an enemy if there are less than 3.
        if (player != null)
        {
            if (enemyList.Count < 3)
            {
                SpawnEnemy();
            }
        }
        
        //Sets a respawn delay.
        if (timer > respawnTime)
        {
            SpawnPlayer();
        }
    }

    //Respawns the player after death if they still have lives.
    public void SpawnPlayer()
    {
        if (player == null)
        {
            if (lives >= 1)
            {
                lives--;
                Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
                PlayMusic();
            } else if(lives <= 0)
            {
                EndGame();
            }
        }
    }

    //Once the player runs out of lives, the game ends.
    private void EndGame()
    {
        print("Quit");
        Application.Quit();
    }

    //Clears the scene on player death.
    public void DestroyAllEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }
    }
}
