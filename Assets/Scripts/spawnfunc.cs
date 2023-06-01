using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class spawnfunc : MonoBehaviour
{

    public GameObject myObject;
    public Transform spawner;

    public List<GameObject> ObjectList = new List<GameObject>();
    public List<GameObject> GridList = new List<GameObject>();

    public ScrollRect scrollRect;
    //public GameObject objectPrefab;
    public GameObject image;



    public void ButtonPressed()
    {
        GameObject newCube = Instantiate(myObject, spawner);
        int randomNumber = Random.Range(100, 999);
        newCube.name = "test" + randomNumber.ToString();
        newCube.transform.localScale = new Vector3(Random.Range(20, 40), Random.Range(20, 40), Random.Range(20, 40));
        Renderer cubeRenderer = newCube.GetComponent<Renderer>();
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        cubeRenderer.material.color = color;
        ObjectList.Add(newCube);

        RectTransform contentTransform = scrollRect.content;
        var newImage = Instantiate(image, contentTransform);
        newImage.name = newCube.name;
        Image imageComponent = newImage.GetComponent<Image>();
        imageComponent.color = color;
        //var girdObject = Instantiate(objectPrefab, contentTransform);
        //girdObject.name = newCube.name;
        //girdObject.transform.localScale = new Vector3(Random.Range(20, 40), Random.Range(20, 40), Random.Range(20, 40));
        //Renderer girdRenderer = girdObject.GetComponent<Renderer>();
        //girdRenderer.material.color = color;
        GridList.Add(newImage);
        //newImage.GetComponent<Button>().onClick.AddListener(() => ClickButtonRemove.Buttonclicked(newImage));
        //GridList.Add(newImage);
        newImage.GetComponent<Button>().onClick.AddListener(() => OnClickRemoveImage(newImage, newCube));
    }

    public void OnClickRemoveImage(GameObject imageToRemove, GameObject cubeToRemove)
    {
        GridList.Remove(imageToRemove);
        ObjectList.Remove(cubeToRemove);
        Destroy(imageToRemove);
        Destroy(cubeToRemove);
    }

    

}

