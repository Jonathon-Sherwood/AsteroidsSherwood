using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed; //This speed is set by the player script on instantiation.
    public GameObject explosionPrefab; //This is used to call the prefab that holds an explosion animation.

    // Update is called once per frame
    void Update()
    {
        //Moves based on player variables once instantiated by player Shoot function.
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    //Collisions are used to check for enemy boats.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);  //Creates the explosion animation.
        Destroy(this.gameObject);
    }

    //Triggers are used to check for the treasure chest.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Gameplay Area"))
        {
            Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity); //Creates the explosion animation.
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
