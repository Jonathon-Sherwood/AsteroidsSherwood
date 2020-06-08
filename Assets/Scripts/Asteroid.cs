using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    //Checks to see if this object collides with another object.
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
       if(otherObject.gameObject == GameManager.instance.player)
        {
            Debug.Log("AAAAAAAAH");
        }
    }
}
