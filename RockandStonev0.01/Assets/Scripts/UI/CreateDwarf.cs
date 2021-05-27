using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RandomNameGeneratorLibrary;

public class CreateDwarf : MonoBehaviour
{
    public Mana mana;
    public GameObject dwarf;

    public void SpawnDwarf()
    {

        Instantiate(dwarf);

        dwarf.GetComponent<Dwarf>().subjectName = this.GetComponent<NameGenerator>().GenerateRandomName();
        dwarf.GetComponent<Dwarf>().subjectJob = "Hauling";
    }
}
