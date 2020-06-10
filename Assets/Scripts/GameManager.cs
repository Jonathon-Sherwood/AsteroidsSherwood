using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public GameObject player;
    public List<GameObject> enemyList;
    
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
