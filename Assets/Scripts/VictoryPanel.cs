using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : MonoBehaviour
{
    public void JogarNovamente(){
        SceneManager.LoadScene("JackTheJumper");
    }

    public void SairDoJogo(){
        SceneManager.LoadScene("MenuInicial");
    }
}
