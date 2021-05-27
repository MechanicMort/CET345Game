using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RandomNameGeneratorLibrary;

public class CreateDwarf : MonoBehaviour
{
    public Mana mana;
    public GameManager gameManager;
    public GameObject dwarf;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void SpawnDwarf()
    {
        if (mana.CurrentMana >= 30 && gameManager.population < gameManager.maxPopulation)
        {
            mana.CurrentMana -= 30;

            GameObject temp = Instantiate(dwarf); ;


            temp.GetComponent<Dwarf>().subjectName = this.GetComponent<NameGenerator>().GenerateRandomName();
            temp.GetComponent<Dwarf>().subjectJob = "Hauling";
        }

    }
}
