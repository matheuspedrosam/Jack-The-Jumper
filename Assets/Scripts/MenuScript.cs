using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject elements;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        Invoke(nameof(MostrarElements), 2.5f);
        highScoreText.text = "HighScore: \n" + PlayerPrefs.GetInt("highscore", 0);
    }

    public void MostrarElements(){
        elements.SetActive(true);
    }

    public void Jogar(){
        SceneManager.LoadScene("JackTheJumper");
    }

    public void Sair(){
        Application.Quit();
    }
}
