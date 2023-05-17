using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnfunc : MonoBehaviour
{
    
    public GameObject myObjects;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(myObjects, transform.position, Quaternion.identity);
        }
    }
}
