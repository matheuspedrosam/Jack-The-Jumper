using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePoint : MonoBehaviour
{
    public GameObject SceneCaverna;
    public GameObject musicSecene;
    public GameObject personagem;


    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){

            SceneCaverna.SetActive(true);
            personagem.SetActive(false);
            SceneCaverna.GetComponent<AudioSource>().Play();

            musicSecene.GetComponent<AudioSource>().Pause();

            StartCoroutine(TextEffect.instace.ShowText());

        }
    }
}
