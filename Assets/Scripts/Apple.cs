using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Apple : MonoBehaviour
{

    private SpriteRenderer spriteRender;
    private CircleCollider2D circleCollider;

    public GameObject collected;

    public int score;

    public AudioSource audioSource;

    
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            audioSource.Play();

            spriteRender.enabled = false;
            circleCollider.enabled = false;

            collected.SetActive(true);

            GameController.instace.totalScore += score;
            GameController.instace.scoreText.text = GameController.instace.totalScore.ToString();

            Destroy(gameObject, 0.3f);
        }
    }
}