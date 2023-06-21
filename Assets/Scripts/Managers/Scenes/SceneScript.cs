using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneScript : MonoBehaviour
{
   public void SceneLoad(string Scene)
   {
        SceneManager.LoadScene(Scene);

        //#fix
        //resolve um pequeno problema que está relacionado com o sistema de pause do jogo
        if(Time.timeScale < 1f)
        {
            Time.timeScale = 1f;
        }       
    }    

    private void Update()
    {
        GameOverEnterClick();
    }
    public void GameOverEnterClick()
    {
        string SceneName = SceneManager.GetActiveScene().name;

        if (SceneName.Equals("Game Over"))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu Inicial");
            }
        }        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Saindo do Jogo...");
    }
}
