using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float asteroidSpeed = 1f; //Adjustable variable for designers to change asteroid flight speed.

    private void Start()
    {
        //Adds this gameobject to the Game Manager's list of existing Asteroids on creation.
        GameManager.instance.enemyList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        //Removes this gameobject to the Game Manager's list of existing Asteroids on destruction.
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    private void Update()
    {
        //Moves the asteroids across the screen.
        transform.position += transform.right * asteroidSpeed * Time.deltaTime;
    }
}
