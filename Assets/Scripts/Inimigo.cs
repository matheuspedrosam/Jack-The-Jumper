using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject personagem;

    // Seguir Jogador
    private float posicaoJogadorX;
    private float posicaoJogadorY;
    public float velocidadeInimigo;
    public float velocidadeInimigoSetada;

    // Soltar fogo
    public GameObject fogo;
    public Transform fogoPos;
    private float timer;

    void Start(){
        velocidadeInimigoSetada = velocidadeInimigo;
    }

    public bool isUpdateActive = true;
    void Update()
    {

        if(isUpdateActive){
            if(gameObject.activeInHierarchy){

                float distance = Vector2.Distance(transform.position, personagem.transform.position);

                if(distance > 18){
                    velocidadeInimigo = 50f;
                } else{
                    velocidadeInimigo = velocidadeInimigoSetada;
                }

                SeguirJogador();
                
                if (distance < 25){
                    timer += Time.deltaTime;

                    if(timer > 1.345){
                        timer = 0;
                        Shoot();
                    }
                }


            }
        }
    }

    public void SetUpdateActive(bool isActive){
        isUpdateActive = isActive;
    }

    public void SeguirJogador(){

        posicaoJogadorX = personagem.transform.position.x + 8f;
        posicaoJogadorY = personagem.transform.position.y + 3f;

        // transform.position = Vector2.Lerp(transform.position, new Vector2(posicaoJogadorX, posicaoJogadorY), velocidadeInimigo * Time.deltaTime);
        if(personagem.activeInHierarchy){
            if (personagem.transform.position.x < 20.7f){
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(28.7f, posicaoJogadorY), velocidadeInimigo * Time.deltaTime);
            } else {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(posicaoJogadorX, posicaoJogadorY), velocidadeInimigo * Time.deltaTime);
            }
        }



        if (personagem.transform.position.x > transform.position.x){
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Shoot(){
        Instantiate(fogo, fogoPos.position, Quaternion.identity);
    }
}
