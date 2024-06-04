using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelogioScript : MonoBehaviour
{

    public GameObject dragao;
    public AudioSource audioS;

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Player"){

            audioS.Play();

            dragao.GetComponent<Inimigo>().SetUpdateActive(false);
            Invoke(nameof(RestartDragon), 10f);
            gameObject.SetActive(false);

        }
    }

    void RestartDragon(){
        dragao.GetComponent<Inimigo>().SetUpdateActive(true);
        Destroy(gameObject);
    }
}
