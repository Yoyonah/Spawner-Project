using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject cube;
    public Transform spawner;
    public List<GameObject> _spawnedCubes = new List<GameObject>();

    public void AddCubeToScene()
    {
        var newCube = Instantiate(cube, spawner);
        var cubeScript = newCube.GetComponent<Cubes>();
        var rnd = new System.Random();
        _spawnedCubes.Add(newCube);

        Vector3 spawnPosition = spawner.position + new Vector3(Random.Range(-200, 300), 0, Random.Range(-200, 300));
        newCube.transform.position = spawnPosition;

        Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
        cubeRigidbody.useGravity = true;
        cubeRigidbody.mass = 0.5f;
        Physics.gravity = new Vector3(0f, -400f, 0f);

        cubeScript.size = new Vector3(Random.Range(0, 700), 0, Random.Range(0, 700));
        cubeScript.rotation = Quaternion.Euler(rnd.Next(1, 360), rnd.Next(1, 360), rnd.Next(1, 360));
        cubeScript.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
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
                GameObject hitCube = hit.collider.gameObject;

                // Remove the cube
                _spawnedCubes.Remove(hitCube);
                Destroy(hitCube);
            }
        }
    }
}
