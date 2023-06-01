using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cubecounter : MonoBehaviour
{
    public TextMeshProUGUI numbertext;
    public spawnfunc spawner; // Corrected the type declaration
    private int lastcount;



    private void Start()
    {
        if (GetComponent<spawnfunc>())
        {
            spawner = GetComponent<spawnfunc>(); // Assign the component reference in Start() or Awake()
        }  
    }

    // Update is called once per frame
    // another function might be used (cube added and cube removed), check function to detect the change of the list
    void Update()
    {
        
        if (lastcount == spawner.ObjectList.Count)
        {    
            return;   
        }

        numbertext.text = spawner.ObjectList.Count.ToString();
        lastcount = spawner.ObjectList.Count;
        
    }

}
