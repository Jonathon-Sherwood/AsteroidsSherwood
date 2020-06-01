using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMode : MonoBehaviour
{
    void Update()
    {
        GameManager.instance.score++;
    }
}
