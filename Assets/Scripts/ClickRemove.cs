using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickRemove : MonoBehaviour
{
    private spawnfunc spawner;
    //public Image targetImage;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawner = GetComponent<spawnfunc>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var clickedObject = hit.transform.gameObject;
                //Debug.Log(clickedObject.name);
                
                var gridToRemove = spawner.GridList.Find(obj => obj.name == clickedObject.name);
                spawner.GridList.Remove(gridToRemove);
                Destroy(gridToRemove);
                
                GameObject objectToRemove = spawner.ObjectList.Find(obj => obj.name == clickedObject.name);
                spawner.ObjectList.Remove(objectToRemove);
                Destroy(objectToRemove);

            }
        }
    }
}

