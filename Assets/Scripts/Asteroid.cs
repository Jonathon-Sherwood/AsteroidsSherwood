using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    //Checks to see if this object collides with another object.
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
       if(otherObject.gameObject == GameManager.instance.player)
        {
            Debug.Log("AAAAAAAAH");
        }
    }
}
