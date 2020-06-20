using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition; //Sets the Game Manager's Player instance to a Vector3
    public float rotationSpeed = 5f; //Allows the designer to adjust rotation speed in the inspector.
    public float maxSpeed = 3f; //Adjustable variable for designers to change ship maximum speed.
    public float minSpeed = 1f; //Adjustable variable for designers to change ship minimum speed.
    private float movementSpeed; //Variable to be chosen randomly between min and max speed.
    private float treasureBoatSpeed; //Variable to be chosen randomly between min and max speed.
    private int health = 2; //Requires the enemyship to be shot twice before destruction. Private to ensure only 2 health.
    public int scoreValue = 1000; //Allows the designer to change how many points destroying this is worth.
    public GameObject pointsPrefab; //Allows the deisgner to attached a visual cue for earning points.

    private void Start()
    {
        //Adds this gameobject to the Game Manager's list of existing Asteroids on creation.
        GameManager.instance.enemyList.Add(this.gameObject);

        movementSpeed = Random.Range(minSpeed, maxSpeed); //Spawns the ship with a random speed.
    }

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

        targetPosition = GameManager.instance.player.transform.position;                         //Sets the Game Manager's Player instance to a Vector3
        Vector3 directionToLook = targetPosition - transform.position;                          //Creates a variable for a vector between the player and position.
        transform.up = directionToLook;                                                         //Moves the red axis towards the player, which is rotation only.
        transform.position += directionToLook.normalized * movementSpeed * Time.deltaTime;      //Moves the ship towards the player.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Only deals damage to this if collision is with bullet.
        if (collision.gameObject.CompareTag("Bullet") && health == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey; //Darkens the ship to indicate damage.
            AudioManager.instance.Play("Explosion");
            health--;
        } else if (collision.gameObject.CompareTag("Bullet") && health == 1) //Destroys ship only if down to one health.
        {
            Instantiate(pointsPrefab, transform.position, Quaternion.identity); //Creates the visual, audio, and score of +1000 score on death.
            GameManager.instance.score += scoreValue;
            AudioManager.instance.Play("Explosion");
            AudioManager.instance.Play("Collect");
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        //Removes this gameobject to the Game Manager's list of existing Asteroids on destruction.
        GameManager.instance.enemyList.Remove(this.gameObject);
    }
}
