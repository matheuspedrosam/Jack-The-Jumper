using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class PortalVitoria : MonoBehaviour
{
    public GameObject personagem;
    public GameObject dragao;

    public GameObject victoryPanel;
    public GameObject textPanel;
    public TextMeshProUGUI highScoreTextUGUI;

    public AudioSource musicSenceAudio;

    public CinemachineVirtualCamera virtualCamera;

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){

            virtualCamera.enabled = false;

            Destroy(dragao);
            Destroy(personagem);

            musicSenceAudio.Stop();

            highScoreTextUGUI.text = "HighScore: \n" + PlayerPrefs.GetInt("highscore", 0).ToString();
            victoryPanel.SetActive(true);
            victoryPanel.GetComponent<AudioSource>().Play();

            Invoke(nameof(ActiveTextPanel), 1f);
        }
    }

    void ActiveTextPanel(){
        textPanel.SetActive(true);
    }
}
