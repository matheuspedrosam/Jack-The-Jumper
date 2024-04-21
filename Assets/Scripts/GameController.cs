using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instace;

    public int totalScore;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        instace = this;
    }

    void Update()
    {
        
    }
}
