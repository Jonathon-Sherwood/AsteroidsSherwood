using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf; //Allows for shorthand throughout code.
    public float turnSpeed = 1f; //Degrees per second.
    public float moveSpeed = 5; //World Space Units per second.
    public float bulletSpeed = 6f; //Adjustable variable for designers to change bullet speed. Highly Recommended to be above player speed.

    public float destroyTime = 2f; //Adjustable variable for designers to decide how long objects last before being destroyed.

    public GameObject bulletPrefab; //Assignable prefab for bullets to be fired by Shoot().

    // Start is called before the first frame update
    void Start()
    {
        //Links this object to GameManager
        GameManager.instance.player = this.gameObject;
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame.
    void Update()
    {
        Movement();
        Shoot();
    }

    void Movement()
    {
        //Rotate player to the left.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        //Rotate player to the right.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
        //Move player forward relative to direction facing.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.right * moveSpeed * Time.deltaTime;
        }
    }

    void Shoot()
    {
        //Allows the player to shoot by creating a prefab Bullet with an attached script.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
            Destroy(bullet, destroyTime);
        }
    }

    //Used for whenever the Player needs to be destroyed after loss in game.
    void Die()
    {
        Destroy(this.gameObject);
    }

    //Whenever the player collides with any object designated by the layer matrix the player dies.
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Die();
    }
}
