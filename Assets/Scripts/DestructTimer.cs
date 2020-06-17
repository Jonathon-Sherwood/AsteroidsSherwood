using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use to Destroy Objects after a set period of time.
/// </summary>
public class DestructTimer : MonoBehaviour
{
    public float deathTimer = 1f; //Adjustable amount of time for the designer in the inspector.

    void Start()
    {
        //Sets the death timer to be above current time by variable amount.
        deathTimer = Time.time + deathTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Once time has gone longer than the variable, destroy object.
        if (deathTimer <= Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}
