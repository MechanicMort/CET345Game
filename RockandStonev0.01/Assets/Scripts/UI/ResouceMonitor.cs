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

        stoneDisplay.text = "Population: " +  gameManager.population;
        stoneDisplay.text += "/" +  gameManager.maxPopulation;
        stoneDisplay.text += "  Stone: " +  gameManager.totalStone;
        stoneDisplay.text += "  Wood: " +  gameManager.totalWood;
        stoneDisplay.text += "  Clay: " +  gameManager.totalClay;
        stoneDisplay.text += "  Stone Slabs: " +  gameManager.totalSlabs;
        stoneDisplay.text += "  Wheat: " +  gameManager.totalWheat;
        stoneDisplay.text += "  Food: " +  gameManager.totalFood;
    }
}
