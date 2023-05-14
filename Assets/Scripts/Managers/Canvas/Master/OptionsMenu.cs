using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;

    public Dropdown ResolutionDropdown;

    Resolution[] Resolutions;

    private void Start()
    {
        Resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        //estrutura de dados List que vai guardar as opções
        List<string> Options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < Resolutions.Length; i++)
        {
            //Cria as opções de resolução do Dropdown
            string Option = Resolutions[i].width + "x" + Resolutions[i].height;                       

            //verifica se a resolução adicionada não está repetida
            if (!Options.Contains(Option))
            {
                //vai adicionando as opções individualmente na variavel
                Options.Add(Option);
            }

            if (Resolutions[i].width == Screen.currentResolution.width &&
                Resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //a variavel options guarda todas as opções de resolução disponiveis 
        ResolutionDropdown.AddOptions(Options);        
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution Resolution = Resolutions[ResolutionIndex];
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
