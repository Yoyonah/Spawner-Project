using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawn : MonoBehaviour
{
    public GameObject[] myObjects;
    public void ButtonPressed()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        Instantiate(myObjects[randomIndex], transform.position, Quaternion.identity);
    }

}
