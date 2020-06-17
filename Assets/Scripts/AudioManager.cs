using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public bool muted = false;
    public bool mutedMusic = false;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
            s.source.time = s.time;
        }
        MuteAudio();
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
        }
        s.source.Play();
    }

    public void MuteAudio()
    {
        if (!muted)
        {
        foreach (Sound s in sounds)
        {

            s.source.volume = s.volume;

        }
            muted = true;
        }
        else if (muted)
        {
            muted = false;
            foreach (Sound s in sounds)
            {
                s.source.volume = 0f;
            }
        }
    }

    public void MuteMusic()
    {
        GameObject musicManager = GameObject.Find("MusicManager");
        AudioSource music = musicManager.GetComponent<AudioSource>();

        if (!mutedMusic)
        {
            music.mute = true;
            mutedMusic = true;
        }
        else if (mutedMusic)
        {
            mutedMusic = false;
            music.mute = false;
        }
    }


}
