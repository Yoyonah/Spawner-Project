using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class CubeManager : MonoBehaviour
{
    public GameObject cube;
    public Transform spawner;
    public List<GameObject> spawnedCubes = new List<GameObject>();
    
    public GameObject image;
    public Transform scrollview;
    public List<GameObject> spawnedImages = new List<GameObject>();

    public void AddCubeToScene()
    {
        int randomnumber = Random.Range(0, 9999);
        var newCube = Instantiate(cube, spawner);
        var cubeScript = newCube.GetComponent<Cubes>();
        var rndColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        var rnd = new System.Random();
        spawnedCubes.Add(newCube);

        newCube.name = "object " + randomnumber.ToString();
        Vector3 spawnPosition = spawner.position + new Vector3(Random.Range(-200, 300), 0, Random.Range(-200, 300));
        newCube.transform.position = spawnPosition;

        Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
        cubeRigidbody.useGravity = true;
        cubeRigidbody.mass = 0.5f;
        Physics.gravity = new Vector3(0f, Random.Range(-200,-600f), 0f);

        newCube.transform.rotation = Quaternion.Euler(rnd.Next(0, 360), rnd.Next(0, 360), rnd.Next(0, 360));
        newCube.GetComponent<Renderer>().material.color = rndColor;
        AddImageToView(rndColor, newCube.name, newCube);
    }

    public void AddImageToView(Color random, String objectName, GameObject cubeReference)
    {
        scrollview = GameObject.Find("Content").transform;
        var newImage = Instantiate(image, scrollview);
        var imageComponent = newImage.GetComponent<Image>();
        imageComponent.color = random;
        spawnedImages.Add(newImage);
        newImage.name = objectName;
        newImage.GetComponent<Button>().onClick.AddListener(() => OnClickRemoveImage(newImage, cubeReference));
    }
    
    public void OnClickRemoveImage(GameObject imageToRemove, GameObject cubeToRemove)
    {
        spawnedImages.Remove(imageToRemove);
        spawnedCubes.Remove(cubeToRemove);
        Destroy(imageToRemove);
        Destroy(cubeToRemove);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
    

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits any objects with the "Cubes" tag
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cubes")) 
            {
                // Get the hit cube object
                GameObject hitObject = hit.collider.gameObject;

                var imageToRemove = spawnedImages.Find(obj => obj.name == hitObject.name);
                var cubeToRemove = spawnedCubes.Find(obj => obj.name == hitObject.name);
                spawnedImages.Remove(imageToRemove);
                Destroy(imageToRemove);
                spawnedCubes.Remove(cubeToRemove);
                Destroy(cubeToRemove);
            }
        }
    }
}
