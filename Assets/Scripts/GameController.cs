using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public static GameController instace;

    // Score
    public int totalScore;
    public int highScore;
    public TextMeshProUGUI scoreText;

    // Lifes
    private int vida = 3;
    public Image heartLifeImage1;
    public Image heartLifeImage2;
    public Image heartLifeImage3;
    public Sprite novaSprite;

    // Game Over
    public GameObject gamerOverPanel;
    public GameObject personagem;
    public AudioClip deathAudio; // Fazer igual para o Win
    private AudioSource audioS;
    public GameObject musicSceneMain;
    public Camera mainCamera;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject dragao;
    public GameObject dragaoAlertContainer;
    public TextMeshProUGUI highScoreNumberUGUI;

    //CheckPoint
    public float actualCheckPointPositionX;
    public float actualCheckPointPositionY;

    //Pause
    public GameObject pausePanel;
    public TextMeshProUGUI highScoreTextPause;

    void Start()
    {
        instace = this;
        audioS = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("highscore", 0);
        // PlayerPrefs.SetInt("highscore", 0);
    }

    void Update(){

        // Pause Game
        if(Input.GetKeyDown(KeyCode.Escape)){
            pausePanel.SetActive(true);
            personagem.SetActive(false);
            Time.timeScale = 0;
            highScoreTextPause.text = "HighScore: \n" + PlayerPrefs.GetInt("highscore", 0).ToString();
        }
    }

    public void ReduzirVida(bool fogo){
        vida--;

        Rigidbody2D personagemRb = personagem.GetComponent<Rigidbody2D>();
        personagemRb.velocity = new Vector2(personagemRb.velocity.x, 0);
        if(!fogo){
            personagem.transform.position = new Vector2(actualCheckPointPositionX, actualCheckPointPositionY);
        }

        if(vida == 2){
            heartLifeImage1.sprite = novaSprite;
            Animator heartLifeImage1Anim = heartLifeImage1.GetComponent<Animator>();
            heartLifeImage1Anim.SetBool("explosion", true);

        } else if (vida == 1){
            heartLifeImage2.sprite = novaSprite;
            Animator heartLifeImage2Anim = heartLifeImage2.GetComponent<Animator>();
            heartLifeImage2Anim.SetBool("explosion", true);

        } else if (vida == 0){
            heartLifeImage3.sprite = novaSprite;
            Animator heartLifeImage3Anim = heartLifeImage3.GetComponent<Animator>();
            heartLifeImage3Anim.SetBool("explosion", true);

        }


        if(vida <= 0){
            GameOver();
        }
    }

    public void AtualizarScore(){
        scoreText.text = totalScore.ToString();
    }

    public void GameOver(){
        AudioSource musicScene = musicSceneMain.GetComponent<AudioSource>();
        musicScene.Stop();

        audioS.clip = deathAudio;
        audioS.Play();

        gamerOverPanel.SetActive(true);
        highScoreNumberUGUI.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        Destroy(personagem);
        Destroy(dragao);
        Destroy(dragaoAlertContainer);

        virtualCamera.enabled = false;
        mainCamera.transform.position = new Vector3(-31.11f, 5f, mainCamera.transform.position.z);
    }

    public void RestartGame(){
        SceneManager.LoadScene("JackTheJumper");
    }

}