using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour
{
    [SerializeField] int counter = 30;
    public TMP_Text counterText;

    public void ButtonClick(){
        if(counter == 0){
            counter = 30;
        }
        else{
            counter--;
        }
    }

    void Update()
    {
        counterText.text = "Монеток: " + counter.ToString();
    }
}
