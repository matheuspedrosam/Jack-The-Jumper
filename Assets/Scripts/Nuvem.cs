using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvem : MonoBehaviour
{

    void Start()
    {
        InvokeRepeating(nameof(MudarPosicao), 0f, 0.01f);
        InvokeRepeating(nameof(RetornarPosicao), 125f, 125f);
    }

    void MudarPosicao(){
        transform.Translate(Vector2.left * Time.deltaTime);
    }

    void RetornarPosicao(){
        transform.position = new Vector3(160, transform.position.y, 0);
    }
}
