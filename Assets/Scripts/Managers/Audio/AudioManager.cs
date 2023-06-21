using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public SoundsConfig[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (SoundsConfig s in sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.Clip;

            s.AudioSource.volume = s.Volume;
            s.AudioSource.pitch = s.Pitch;
            s.AudioSource.loop = s.Loop;
        }
    }

    public void Play(string name)
    {
        SoundsConfig s
            = Array.Find(sounds, sound => sound.Name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.AudioSource.Play();
    }

    void Start()
    {
        //criar um sistema que verifique qual cena/fase é, e mudar a música de fundo
        Play("Menu");
    }
}
