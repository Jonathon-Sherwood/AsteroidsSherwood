using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed; //This speed is set by the player script on instantiation.

    // Update is called once per frame
    void Update()
    {
        //Moves based on player variables once instantiated by player Shoot function.
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    //Collisions are used to check for enemy boats.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    //Triggers are used to check for the treasure chest.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Gameplay Area"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
