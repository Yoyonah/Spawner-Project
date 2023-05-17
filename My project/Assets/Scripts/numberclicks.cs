using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class numberclicks : MonoBehaviour
{
    public TextMeshProUGUI numbertext;
    int counter;


    public void ButtonPressed()
    {
        counter++;
        numbertext.text = counter + "";

    }
}
