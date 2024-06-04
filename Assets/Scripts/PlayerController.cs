using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Mov
    public float velocidade = 1f;

    // Jump
    private Rigidbody2D rb;
    public float jumpForce = 1f;
    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask layerChao;

    // Animation
    private Animator anim;

    // Dano Queda
    private bool noChao = true;
    private float alturaParaDano = 10f;
    private float alturaInicial;

    // Pontuar
    private Score score;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = FindObjectOfType<Score>();
    }

    void Update()
    {
        // Debug.DrawRay(detectaChao.position, Vector3.down * 0.1f, Color.green);
        // taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.4f ou 0.6f, layerChao);
        taNoChao = Physics2D.Raycast(detectaChao.position, Vector2.down, 0.1f, layerChao);

        Move();

        Jump();

        DanoDeQueda();
    }

    void Move(){
        if (Input.GetAxisRaw("Horizontal") > 0) {
            transform.Translate(velocidade * Time.deltaTime * Vector2.right);
            transform.localScale = new Vector3(1, 1, 0);
            anim.SetBool("run", true);

        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            transform.Translate(velocidade * Time.deltaTime * Vector2.left);
            transform.localScale = new Vector3(-1, 1, 0);
            anim.SetBool("run", true);

        } else{
            anim.SetBool("run", false);
        }
    }

    void Jump(){

        if(Input.GetButtonDown("Jump") && taNoChao){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        } else {
            anim.SetBool("jump", false);
        }
    }

    void DanoDeQueda(){
        if(transform.position.y > 0){
            if(noChao && !taNoChao){
                noChao = false;
                alturaInicial = transform.position.y;
            } else if(!noChao && taNoChao){
                noChao = true;
                float alturaFinal = transform.position.y;
                float distanciaQueda = alturaInicial - alturaFinal;

                if(distanciaQueda > alturaParaDano){
                    GameController.instace.ReduzirVida(false);
                    alturaInicial = transform.position.y;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.tag == "GalhoArvorePoint"){
            score.Pontuar();
            coll.gameObject.SetActive(false);
        }
    }
}
