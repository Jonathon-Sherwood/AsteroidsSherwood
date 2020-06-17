using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition; //Sets the Game Manager's Player instance to a Vector3
    public float rotationSpeed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        
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

        targetPosition = GameManager.instance.player.transform.position; //Sets the Game Manager's Player instance to a Vector3
        Vector3 directionToLook = targetPosition - transform.position;   //Creates a variable for a vector between the player and position.
        transform.up = directionToLook;                                  //Moves the red axis towards the player, which is rotation only.

        //TODO: Learn RotateTowards
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right, transform.forward), rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Drops a treasure chest for the player to pick up on destruction only if shot.
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Instantiate(treasureChestPrefab, transform.position, Quaternion.identity);
            AudioManager.instance.Play("Explosion");
            Destroy(this.gameObject);
        }
    }
}
