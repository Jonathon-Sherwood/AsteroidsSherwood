using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf;
    public float turnSpeed = 1f; //Degrees per second.
    public float moveSpeed = 5; //World Space Units per second.

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this.gameObject;
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    void Movement()
    {
        //Rotate player to the left
        if (Input.GetKey(KeyCode.LeftArrow))
            {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
            }
        //Rotate player to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
        //Move player forward
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.right * moveSpeed * Time.deltaTime;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TODO: Implement shooting
            Debug.Log("Shooting Not Implemented Yet");
        }
    }
}
