using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public static bool GameIsPaused = false;
    
    public GameObject PauseMenuUI, EnterTxt;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        EnterTxt.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        EnterTxt.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
