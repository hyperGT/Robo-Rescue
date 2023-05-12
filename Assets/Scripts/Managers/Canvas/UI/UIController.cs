using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [Header("UI components")]
    [SerializeField] private Image[] LifeUI;
    
    [SerializeField] private Text ScoreUI;
   
    [SerializeField] private Text LivesUI;

    [Header("Prefixed Variables")]
    public int LifeBar = 10;
    public int TotalLives = 3;
    public int CurrentScorePlayer = 0;

    [SerializeField] private GameObject GameOverPanel;

    void Update()
    {
        GameOverPanel.SetActive(false);
        SaveScore();
        LivesSystem();
        PlayerHealthSystem();
    }

    void SaveScore()
    {
        ScoreUI.text = CurrentScorePlayer.ToString("00000000");
    }

    void LivesSystem()
    {
        LivesUI.text = TotalLives.ToString();       
    }

    void PlayerHealthSystem()
    {
        // sistema simples de reduzir as vidas do player 
        if(LifeBar < 1)
        {
            Debug.Log("Perdeu uma vida");
            TotalLives--;
            LifeBar = 10;            
        }
        // verificação de otimização
        if (LifeBar > 10)
        {
            LifeBar = 10;
        }
        // condição do game over
        else if(TotalLives < 1)
        {
            TotalLives = 0;
            Debug.Log("Game Over");
            GameOverPanel.SetActive(true);
        }
        
        // controle de repetição para quando o player tomar dano, deixar um componente de sua vida transparente
        for(int i = 0; i <= LifeUI.Length-1 ; i++)
        {
            LifeUI[i].color = new Color(1, 1, 1, 0);
        }
        for (int i = 0; i < LifeBar ; i++)
        {
            LifeUI[i].color = new Color(1, 1, 1, 0.8f);
        }

    }
}
