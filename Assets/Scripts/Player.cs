﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf; //Allows for shorthand throughout code.
    public GameObject explosionPrefab; //This is used to call the prefab that holds an explosion animation.
    public float turnSpeed = 1f; //Degrees per second.
    public float moveSpeed = 5; //World Space Units per second.
    public float bulletSpeed = 6f; //Adjustable variable for designers to change bullet speed. Highly Recommended to be above player speed.
    public float destroyTime = 2f; //Adjustable variable for designers to decide how long objects last before being destroyed.

    public GameObject bulletPrefab; //Assignable prefab for bullets to be fired by Shoot().

    private Animator anim; //Assigns the variable to this object's animator.

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Links this object to GameManager
        GameManager.instance.player = this.gameObject;
        tf = gameObject.GetComponent<Transform>();

        audioSource = GetComponent<AudioSource>(); //Sets the audiosource containing Cannon Fire to a variable.

        anim = GetComponent<Animator>();  //Sets variable to this script's animator.
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        //Rotate player to the right.
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
        //Move player forward relative to direction facing.
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            tf.position += tf.up * moveSpeed * Time.deltaTime;
            anim.SetBool("Moving", true); //Activates the animator's movement animation.
        } else
        {
            anim.SetBool("Moving", false); //Deactivates the animator's movement animation.
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
            AudioManager.instance.Play("Cannon Fire");
        }
    }

    //Used for whenever the Player needs to be destroyed after loss in game.
    public void Die()
    {
        AudioManager.instance.Play("Player Death");
        Destroy(GameObject.Find("Music(Clone)"));    //Finds and destroys music object to mute after death.
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); //Creates the explosion animation.
        GameManager.instance.DestroyAllEnemies();
        GameManager.instance.timer = 0;  //Restarts timer when player dies for respawn.
        Destroy(this.gameObject);
    }

    //Whenever the player collides with any object designated by the layer matrix the player and object are destroyed.
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Die();
    }

    private void OnDestroy()
    {
        //Removes this gameobject to the Game Manager's list of existing Asteroids on destruction.
        GameManager.instance.player = null;
    }
}
