using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Sound
{
    public AudioClip clip; //Allows a designer to assign audio clips to the manager.

    public string name; //Allows scripts to call clips based on name.


    //Sets the parameters for the audio clips.
    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
    [Range(0f, 5f)]
    public float time;

    public bool loop;
    public bool mute;

    [HideInInspector]
    public AudioSource source;

}
