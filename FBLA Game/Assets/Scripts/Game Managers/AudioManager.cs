using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // creates sound variables
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    // plays the specified sound
    public void Play(string soundName)
    {
        Sound sound = Array.Find(sounds, s => s.name == soundName);

        if (sound == null)
        {
            print("Sound " + name + " not found!");
            return;
        }

        sound.source.Play();
    }
}
