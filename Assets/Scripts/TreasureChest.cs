using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public GameObject pointsPrefab; //Sets the animated points as a variable to be instantiated.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This is to avoid the gameplay area from destroying all objects.
        if(!collision.gameObject.CompareTag("Gameplay Area"))
        {
            //If the player collects the chest they earn score, anything else just destroys it.
            if (collision.gameObject.CompareTag("Player"))
            {
                Instantiate(pointsPrefab, transform.position, Quaternion.identity);
                GameManager.instance.score += 500;
            }
            Destroy(this.gameObject);
        }
    }
}
