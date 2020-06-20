﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    //Destroys any Gameobject that leaves the play area that spans the screen.
    private void OnTriggerExit2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);

        if (otherObject.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Explosion");
            GameManager.instance.respawnTime += GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().respawnTime;
        }

    }
}
