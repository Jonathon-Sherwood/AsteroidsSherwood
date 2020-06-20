using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Allows any script to call the Game Manager.
    public int score; //Placeholder int to be tweaked by other objects such as ships.
    public int lives = 3;
    public float spawnDistance; //Allows the designer to set a random distance from the spawner.
    [HideInInspector] public float respawnTime;
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

        Instantiate(enemyToSpawn, new Vector3(newPosition.x, newPosition.y, 0), Quaternion.identity);
    }

    private void Update()
    {
        scoreTracker.text = score.ToString(); //Sets the canvas text element to the player's score.

        if (player != null)
        {
            if (enemyList.Count < 3)
            {
                SpawnEnemy();
            }
        }
        if (Time.time > respawnTime)
        {
            respawnTime = 0;
            SpawnPlayer();
        }

        print(respawnTime);
    }


    public void SpawnPlayer()
    {
        if (player == null)
        {
            if (lives >= 0)
            {
                Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
                PlayMusic();
            }
        }
    }

    public void DestroyAllEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }
    }
}
