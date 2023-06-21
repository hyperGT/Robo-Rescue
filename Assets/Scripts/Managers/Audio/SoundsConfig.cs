using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundsConfig 
{
    public string Name;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;

    [Range(.1f, 3f)] //.1f = 0.1
    public float Pitch;

    public bool Loop;

    [HideInInspector]
    public AudioSource AudioSource;
}
