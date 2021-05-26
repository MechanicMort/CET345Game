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
    public float productivity;
    public float productivityMax;

    public string subjectName;
    public string subjectStatus;
    public string subjectJob;

    public bool hasJob;

    public int invSize;

    public bool isFoodInInv;


    public int foodPos;

    public Vector3 workPlace;

    public GameObject workLedger;
    public GameObject storageLocation;
    public GameObject[] inventory;


    private void Start()
    {
        this.gameObject.name = subjectName;
        inventory = new GameObject[invSize];
        StartCoroutine(Hungry());
        StartCoroutine(reduceHealth());
    }


    public void Eat()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            
        }
        if (Hunger <= 50 && isFoodInInv)
        {

        }
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
        if (Hunger <= 15)
        {
            Health -= 0.5f;
        }
        else
        {
            Health += 0.05f;
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

    public float Work()
    {
        productivity = productivityMax * Happiness/100;
        return productivity;
    }

    public void Die()
    {
        if (Health <= 0)
        {
            //die and drop inv
        }
    }
    public void Update()
    {
        
    }
}
