using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dwarf : MonoBehaviour
{

    public float maxHealth;
    public float Health;
    public float maxHunger;
    public float Hunger;
    public float maxHappiness;
    public float Happiness;

    public string subjectName;
    public string subjectStatus;
    public string subjectJob;

    public int invSize;

    public GameObject workLedger;
    public GameObject storageLocation;
    public GameObject[] inventory;


    private void Start()
    {

        inventory = new GameObject[invSize];
        StartCoroutine(Hungry());
        StartCoroutine(reduceHealth());
    }


    private IEnumerator Hungry()
    {
        yield return new WaitForSeconds(0.5f);
        if (Hunger > 1)
        {
            Hunger -= 0.5f;
        }

        if (Hunger <= 30 && !subjectStatus.Contains(" Hungry "))
        {
            subjectStatus += "Hungry";
        }
        else if (Hunger > 50)
        {
            subjectStatus.Replace(" Hungry \n", "");
        }
    }


    private IEnumerator reduceHealth()
    {
        yield return new WaitForSeconds(0.5f);
        if (Hunger <= 3)
        {
            Health -= 0.5f;
        }

        if (Health <= 30 && !subjectStatus.Contains(" Starving "))
        {
            subjectStatus += "Starving \n";
        }
        else if (Hunger > 50)
        {
            subjectStatus.Replace(" Starving ", "");
        }

        if (Health <= 30 && !subjectStatus.Contains(" Dieing "))
        {
            subjectStatus += " Dieing \n";
        }
        else if (Health > 50)
        {
            subjectStatus.Replace(" Dieing ", "");
        }

    }
    public void UpdateInventorySize()
    {
        GameObject[] tempInve = inventory;

        inventory = new GameObject[invSize];
        for (int i = 0; i < tempInve.Length; i++)
        {
            inventory[i] = tempInve[i];
        }
    }

    public void Die()
    {

    }
    public void Update()
    {
        
    }
}
