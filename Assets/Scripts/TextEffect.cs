using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEffect : MonoBehaviour
{

    private string myText = "Jack ao entrar na caverna, encontrou um machado, e lá na frente se deparou com um dragão e ao seu lado os ovos dourados, logo jack capturou os ovos e correu, mas o dragão não ira deixar fácil...";
    public TextMeshProUGUI textGUI;
    private char[] ctr;
    public static TextEffect instace;

    // Start is called before the first frame update
    void Start()
    {
        ctr = myText.ToCharArray();

        instace = this;
    }

    public IEnumerator ShowText(){

        int count = 0;
        while(count < ctr.Length){
            yield return new WaitForSeconds(0.07f);
            textGUI.text += ctr[count];
            count++;
        }

    }
}
