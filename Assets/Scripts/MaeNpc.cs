using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaeNpc : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);

        if(transform.position.x >= -34f){
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else if(transform.position.x < -43f){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
