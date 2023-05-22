using System.Collections.Generic;
using UnityEngine;

public class ClickRemove : MonoBehaviour
{
    private spawnfunc spawner;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawner = GetComponent<spawnfunc>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.transform.gameObject;
                
                GameObject gridToRemove = spawner.GridList.Find(obj => obj.name == clickedObject.name);
                spawner.GridList.Remove(gridToRemove);
                Destroy(gridToRemove);
                GameObject objectToRemove = spawner.ObjectList.Find(obj => obj.name == clickedObject.name);
                spawner.ObjectList.Remove(objectToRemove);
                Destroy(objectToRemove);
                

                
            }
        }
    }
}

