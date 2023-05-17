using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeCounter : MonoBehaviour
{
    public CubeManager cubeManager;
    private TextMeshProUGUI counterText;

    private void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Update the counter text with the current cube count
        counterText.text = "Cube Count: " + cubeManager._spawnedCubes.Count.ToString();
    }
}
