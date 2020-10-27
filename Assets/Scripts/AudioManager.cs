using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //public Sound[] sounds;
    public Sound[] sounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = GetComponent<AudioSource>();
        }
    }


    public void PlaySound(int i)
    {
        Debug.Log("Play Sound");
        /*Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }*/
        sounds[i].source.Play();
    }
}
