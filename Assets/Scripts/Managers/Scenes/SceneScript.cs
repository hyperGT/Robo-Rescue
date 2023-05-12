using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneScript : MonoBehaviour
{
   public void SceneLoad(string Scene)
   {
        SceneManager.LoadScene(Scene);
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
