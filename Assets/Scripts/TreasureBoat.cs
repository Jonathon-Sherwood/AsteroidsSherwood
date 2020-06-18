using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoat : MonoBehaviour
{
    public GameObject treasureChestPrefab; //Attaches the treasure chest pickup to the boat for instantiating.

    private Vector3 directionToMove; //Hard-Coded vector assigned to the player through the game manager.

    public float treasureBoatMaxSpeed = 3f; //Adjustable variable for designers to change ship maximum speed.
    public float treasureBoatMinSpeed = 1f; //Adjustable variable for designers to change ship minimum speed.
    private float treasureBoatSpeed; //Variable to be chosen randomly between min and max speed.

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

        treasureBoatSpeed = Random.Range(treasureBoatMinSpeed, treasureBoatMaxSpeed);
    }

    private void Update()
    {
        //Moves the ships towards the player.
        transform.position += directionToMove * treasureBoatSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Drops a treasure chest for the player to pick up on destruction only if shot.
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(treasureChestPrefab, transform.position, Quaternion.identity);
        }
        AudioManager.instance.Play("Explosion");
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        //Removes this gameobject to the Game Manager's list of existing Asteroids on destruction.
        GameManager.instance.enemyList.Remove(this.gameObject);
    }
}
