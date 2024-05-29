using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instace;

    public int totalScore;
    public TextMeshProUGUI scoreText;

    private int vida = 3;
    public Image heartLifeImage1;
    public Image heartLifeImage2;
    public Image heartLifeImage3;
    public Sprite novaSprite;

    void Start()
    {
        instace = this;
    }

    void Update()
    {
        
    }

    public void ReduzirVida(){
        vida--;

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


        Debug.Log("Vida Atual: " + vida);

        if(vida <= 0){
            Debug.Log("Game Over");
        }
    }

    public void AtualizarScore(){
        scoreText.text = totalScore.ToString();
    }
}


    // Heart Anim ->
    // StartCoroutine(InvokeComParametroCoroutine(StopAnimation, heartLifeImage1Anim, 0.4f));
    // StartCoroutine(InvokeComParametroCoroutine(StopAnimation, heartLifeImage2Anim, 0.4f));
    // StartCoroutine(InvokeComParametroCoroutine(StopAnimation, heartLifeImage3Anim, 0.4f));

    // IEnumerator InvokeComParametroCoroutine(System.Action<Animator> metodo, Animator parametro, float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     metodo(parametro);
    // }

    // private void StopAnimation(Animator heartLifeAnim)
    // {
    //     heartLifeAnim.StopPlayback();
    // }