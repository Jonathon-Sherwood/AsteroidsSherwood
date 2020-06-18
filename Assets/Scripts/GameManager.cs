using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Allows any script to call the Game Manager.
    public int score; //Placeholder int to be tweaked by other objects such as ships.
    public float spawnDistance; //Allows the designer to set a random distance from the spawner.
    public GameObject player; //Allows the designer to assign the player object in inspector.
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

    private void Start()
    {
        AudioManager.instance.Play("Music");
    }

    void SpawnEnemy()
    {

        //TODO: Not yet fully implemented.

        //Assigns the Spawn Point to any random spawnpoint assigned in the inspector.
        Transform spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];

        //Picks a point within distance of spawn point to spawn at.
        Vector3 randomVector = Random.insideUnitCircle;
        Vector3 newPosition = spawnPoint.position + (randomVector * spawnDistance);
    }

    private void Update()
    {
        scoreTracker.text = score.ToString(); //Sets the canvas text element to the player's score.
    }
}
