using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CubeListDisplay : MonoBehaviour
{
    public GameObject image;
    public Transform scrollview;
    public List<GameObject> _spawnedImages = new List<GameObject>();

    public void AddImageToView()
    {
        var newImage = Instantiate(image, scrollview);
        _spawnedImages.Add(newImage);
    }


}
