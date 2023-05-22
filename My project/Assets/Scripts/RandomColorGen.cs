using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class RandomColorGen : MonoBehaviour
{
   public Renderer objectRenderer;
   

   public void Start()
   {
      objectRenderer = GetComponent<Renderer>();

      var randomColor = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));

      objectRenderer.material.color = randomColor;
      
   }
}
