﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoat : MonoBehaviour
{
    private Vector3 directionToMove; //Hard-Coded vector assigned to the player through the game manager.

    public float treasureBoatSpeed = 1f; //Adjustable variable for designers to change asteroid flight speed.

    private void Start()
    {
        //Adds this gameobject to the Game Manager's list of existing Asteroids on creation.
        GameManager.instance.enemyList.Add(this.gameObject);

        //Sets the direction to move as the vector between current position and player.
        directionToMove = GameManager.instance.player.transform.position - transform.position;

        //Maintains the current Vector3 but changes its length to 1.0.
        directionToMove.Normalize();

        //Spawns the ships facing the direction they are moving.
        transform.up = directionToMove;
    }

    private void Update()
    {
        //Moves the asteroids towards the player.
        transform.position += directionToMove * treasureBoatSpeed * Time.deltaTime;
    }


    private void OnDestroy()
    {
        //Removes this gameobject to the Game Manager's list of existing Asteroids on destruction.
        GameManager.instance.enemyList.Remove(this.gameObject);
    }
}