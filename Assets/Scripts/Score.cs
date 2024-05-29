using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private bool isAlreadyJumped = false;
    public int score;

    // void Start(){}

    // void Update(){}

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player"))
        {
            if(isAlreadyJumped == false){
                GameController.instace.totalScore += score;
                GameController.instace.AtualizarScore();
            }

            isAlreadyJumped = true;
        }
    }
}
