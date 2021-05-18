using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float researchTier;
    public Recipe[] recipes;
    public float totalStone;
    public float totalWood;
    public float totalClay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalStone = 0;
        totalClay = 0;
        totalWood = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("StorageBuilding").Length; i++)
        {
            totalStone += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().stoneStored;
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("StorageBuilding").Length; i++)
        {
            totalWood += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().woodStored;
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("StorageBuilding").Length; i++)
        {
            totalClay += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().clayStored;
        }

    }
}
