using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FogoDragaoScript : MonoBehaviour
{
    private GameObject personagem;
    private Rigidbody2D rb;
    public float force;
    private float timer;

    void Start()
    {
        personagem = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = personagem.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = (float)(Math.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(0, 0, rot + 5);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "Player"){
            personagem.GetComponent<Animator>().SetTrigger("hit");
            Destroy(gameObject);
            GameController.instace.ReduzirVida(true);
        }
    }
}
