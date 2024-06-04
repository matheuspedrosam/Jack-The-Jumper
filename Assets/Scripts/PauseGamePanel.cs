using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject personagem;

    public void Continue(){
        gameObject.SetActive(false);
        personagem.SetActive(true);
        Time.timeScale = 1;
    }

    public void Reiniciar(){
        Time.timeScale = 1;
        SceneManager.LoadScene("JackTheJumper");
    }

    public void Sair(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuInicial");
    }
}
