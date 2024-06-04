using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCavernaOut : MonoBehaviour
{
    public GameObject scenePoint;
    public GameObject arvoreCaverna;
    public GameObject paredeIvisivelCaverna;
    public GameObject galhosArvore2;
    public GameObject dragao;
    public GameObject personagem;
    public GameObject musicSecene;
    public GameObject relogio;
    public GameObject ovos;
    public GameObject machado;
    public AudioClip novaMusica;

    public void ExitScene(){

        Destroy(scenePoint);

        personagem.SetActive(true);
        gameObject.SetActive(false);
        arvoreCaverna.SetActive(true);
        paredeIvisivelCaverna.SetActive(true);
        galhosArvore2.SetActive(true);
        relogio.SetActive(true);
        ovos.SetActive(true);
        machado.SetActive(true);
        dragao.SetActive(true);

        personagem.transform.position = new Vector2(64.01f, 107.21f);
        personagem.transform.localScale = new Vector3(-1, 1, 1);
        dragao.transform.position = new Vector2(70.50f, 111.72f);

        musicSecene.GetComponent<AudioSource>().clip = novaMusica;
        musicSecene.GetComponent<AudioSource>().Play();
    }
}
