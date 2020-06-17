using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition; //Sets the Game Manager's Player instance to a Vector3
    public float rotationSpeed = 5f; //Allows the designer to adjust rotation speed in the inspector.
    private int health = 2; //Requires the enemyship to be shot twice before destruction. Private to ensure only 2 health.
    public int scoreValue = 1000; //Allows the designer to change how many points destroying this is worth.

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //Prevents the game from crashing when the player is destroyed.
        if(GameManager.instance.player == null)
            return;

        targetPosition = GameManager.instance.player.transform.position; //Sets the Game Manager's Player instance to a Vector3
        Vector3 directionToLook = targetPosition - transform.position;   //Creates a variable for a vector between the player and position.
        transform.up = directionToLook;                                  //Moves the red axis towards the player, which is rotation only.

        //TODO: Learn RotateTowards
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right, transform.forward), rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Only deals damage to this if collision is with bullet.
        if (collision.gameObject.CompareTag("Bullet") && health == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            AudioManager.instance.Play("Explosion");
            health--;
        } else if (collision.gameObject.CompareTag("Bullet") && health == 1) //Destroys ship only if down to one health and adds score.
        {
            //Instantiate(treasureChestPrefab, transform.position, Quaternion.identity);
            GameManager.instance.score += scoreValue;
            AudioManager.instance.Play("Explosion");
            AudioManager.instance.Play("Collect");
            Destroy(this.gameObject);
        }
    }
}
