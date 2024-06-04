using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            if(anim.GetBool("bandeiraCapturada") == false){
                audioSource.Play();
                GameController.instace.actualCheckPointPositionX = transform.position.x;
                GameController.instace.actualCheckPointPositionY = transform.position.y + 1;
            }
            anim.SetBool("bandeiraCapturada", true);
        }
    }
}
