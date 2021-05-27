using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float researchTier;
    public Recipe[] recipes;

    public ArrayList deliveryList = new ArrayList();

    public float totalStone;
    public float totalFood;
    public float totalWheat;
    public float totalWood;
    public float totalClay;
    public float totalSlabs;


    public float population;
    public float maxPopulation;
    // Start is called before the first frame update
    void Start()
    {

        List<Recipe> tempList = new List<Recipe>();
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Recipe").Length; i++)
        {
            tempList.Add(GameObject.FindGameObjectsWithTag("Recipe")[i].GetComponent<Recipe>());
        }
        recipes = tempList.ToArray();
    }




    public Recipe[] getRecipes()
    {
        return recipes;
    }

    public Recipe getThisRecipe(string recipeName)
    {
        for (int i = 0; i < recipes.Length; i++)
        {
            if (recipes[i].recipeName == recipeName)
            {
                return recipes[i];
            }
        }

        return null;

    }


    // Update is called once per frame
    void Update()
    {
        population = GameObject.FindGameObjectsWithTag("Dwarf").Length;
        maxPopulation = GameObject.FindGameObjectsWithTag("Home").Length * 2;
        totalStone = 0;
        totalClay = 0;
        totalWood = 0;
        totalFood = 0;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("StorageBuilding").Length; i++)
        {
         
            totalStone += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().stoneStored;
            totalWood += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().woodStored;
            totalClay += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().clayStored;
            totalSlabs += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().slabsStored;
            totalFood += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().foodStored ;
            totalWheat += GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().wheatStored;
        }
    


    }
}
