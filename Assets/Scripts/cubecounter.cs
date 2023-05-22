using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cubecounter : MonoBehaviour
{
    public TextMeshProUGUI numbertext;
    private spawnfunc spawner; // Corrected the type declaration



    private void Start()
    {
        if (GetComponent<spawnfunc>())
        {
            spawner = GetComponent<spawnfunc>(); // Assign the component reference in Start() or Awake()
        }
        else
        {

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        numbertext.text = spawner.ObjectList.Count.ToString();
    }
}
