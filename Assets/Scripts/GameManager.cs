using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Allows any script to call the Game Manager.
    public int score; //Placeholder int to be tweaked by other objects such as asteroids.
    public GameObject player; //Allows the designer to assign the player object in inspector.
    public List<GameObject> enemyList; //This list is attached to asteroid objects that will fill this list.
    
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
}
