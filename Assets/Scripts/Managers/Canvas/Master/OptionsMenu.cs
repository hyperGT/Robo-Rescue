using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{    

    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;

    [SerializeField] private Dropdown ResolutionDropdown;

    private Resolution[] Resolutions;
    private List<Resolution> FilteredResolutions;

    private float CurrentRefreshRate;
    private int CurrentResolutionIndex = 0;
    void Start()
    {
        Resolutions = Screen.resolutions;
        FilteredResolutions = new List<Resolution>();

        ResolutionDropdown.ClearOptions();
        CurrentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < Resolutions.Length; i++)
        {
            if (Resolutions[i].refreshRate == CurrentRefreshRate)
            {
                FilteredResolutions.Add(Resolutions[i]);
            }
        }

        //estrutura de dados List que vai guardar as opções        
        List<string> Options = new List<string>();

        for (int i = 0; i < FilteredResolutions.Count; i++)
        {
            string Option = FilteredResolutions[i].width + " x " + FilteredResolutions[i].height + " " + FilteredResolutions[i].refreshRate + "Hz";
            

            //vai adicionando as opções individualmente na variavel
            Options.Add(Option);

            if (FilteredResolutions[i].width == Screen.width
                && FilteredResolutions[i].height == Screen.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        //Cria as opções de resolução do Dropdown
        ResolutionDropdown.AddOptions(Options);
        ResolutionDropdown.value = CurrentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution Resolution = FilteredResolutions[ResolutionIndex];
        Screen.SetResolution(Resolution.width, Resolution.height, Screen.fullScreen);
    }                                                                           

    public void SetMusicVolume(float MusicVolume)
    {
        MusicMixer.SetFloat("MusicVolume", MusicVolume);
        Debug.Log(MusicVolume);
    }

    public void SetSFXVolume(float SFXVolume)
    {
        SFXMixer.SetFloat("SFXVolume", SFXVolume);
        Debug.Log(SFXVolume);        
    }

    public void FullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }

}
