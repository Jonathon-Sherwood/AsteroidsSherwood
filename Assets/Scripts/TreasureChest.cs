using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Gameplay Area"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.score += 500;
            }

            Destroy(this.gameObject);
        }
    }
}
