using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RelogioScript : MonoBehaviour
{

    public GameObject dragao;
    public AudioSource audioS;
    public float DragaoParadoTiming = 10;
    public GameObject dragaoAlertContainer;
    public TextMeshProUGUI DragaoParadoTimingTextUGUI;
    private bool isUpdateActive = false; 

    void Update(){
        if(isUpdateActive){
            DragaoParadoTimingTextUGUI.text = Mathf.RoundToInt(DragaoParadoTiming).ToString(); 

            DragaoParadoTiming -= Time.deltaTime;

            if(DragaoParadoTiming <= 0){
                isUpdateActive = false;
                dragaoAlertContainer.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Player"){

            audioS.Play();

            dragao.GetComponent<Inimigo>().SetUpdateActive(false);
            dragaoAlertContainer.SetActive(true);
            isUpdateActive = true;
            Invoke(nameof(RestartDragon), 10f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    void RestartDragon(){
        dragao.GetComponent<Inimigo>().SetUpdateActive(true);
        Destroy(gameObject);
    }
}
