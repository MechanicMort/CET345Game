using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResouceMonitor : MonoBehaviour
{
    public Text stoneDisplay;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        stoneDisplay.text = "Stone" +  gameManager.Resources[0].ToString();
    }
}
