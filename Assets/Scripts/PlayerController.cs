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

    //Animation
    private Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.6f, layerChao);

        Move();

        Jump();
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
}
