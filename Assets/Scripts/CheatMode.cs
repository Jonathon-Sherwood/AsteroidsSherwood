using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMode : MonoBehaviour
{
    void Update()
    {
        //Adds consistent score to Game Manager to test for linked components.
        GameManager.instance.score++;
    }
}
