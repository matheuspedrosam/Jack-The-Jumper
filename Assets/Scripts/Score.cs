using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    private bool highScoreAlreadyShowed = false;
    
    public int multiplicadorScore = 1;
    public float timeLimit = 3f;
    private float timer = 0f;
    private bool isCounting = false;
    private int platformCount = 0;

    public TextMeshProUGUI multiplicadorScoreText;
    public GameObject highScoreText;

    // void Start(){}

    void Update(){
        if(isCounting){
            timer += Time.deltaTime;

            if(timer >= timeLimit){
                isCounting = false;
                platformCount = 0;
                multiplicadorScore = 1;
                timer = 0;
                multiplicadorScoreText.text = multiplicadorScore.ToString();
            }

            if(platformCount >= 3){
                if(timer <= timeLimit){
                    multiplicadorScore += 1;
                    GetComponents<AudioSource>()[0].Play();
                    timer = 0;
                    platformCount = 0;
                    multiplicadorScoreText.text = multiplicadorScore.ToString();
                } else{
                    platformCount = 0;
                    timer = 0;
                    isCounting = false;
                    multiplicadorScore = 1;
                    multiplicadorScoreText.text = multiplicadorScore.ToString();
                }
            }
        }
    }

    public void Pontuar(){

        if (!isCounting)
        {
            isCounting = true;
            timer = 0f;
        }

        platformCount++;

        GameController.instace.totalScore += score * multiplicadorScore;
        GameController.instace.AtualizarScore();

        if(GameController.instace.totalScore > GameController.instace.highScore){
            PlayerPrefs.SetInt("highscore", GameController.instace.totalScore);
            if(!highScoreAlreadyShowed){
                highScoreText.SetActive(true);
                GetComponents<AudioSource>()[1].Play();
                Invoke(nameof(StopHighScoreTextAudio), 1f);
                highScoreAlreadyShowed = true;
            }
        }

    }
    
    void StopHighScoreTextAudio(){
        GetComponents<AudioSource>()[1].Stop();
    }
}
