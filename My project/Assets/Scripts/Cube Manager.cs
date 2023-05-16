using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject cube;
    public Transform spawner;
    private List<Cubes> _spawnedCubes = new List<Cubes>();
    
    public void AddCubeToScene()
    {
        var newCube = Instantiate(cube, spawner);
        var cubeScript = newCube.GetComponent<Cubes>();
        var rnd = new System.Random();
        cubeScript.size = new Vector3(rnd.Next(1,200),rnd.Next(1,200),rnd.Next(1,200));
        cubeScript.rotation = Quaternion.Euler(rnd.Next(1, 360), rnd.Next(1, 360), rnd.Next(1, 360));
        //cubeScript.color = ();
        

    }
}
