using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RandomNameGeneratorLibrary;
public class NameGenerator : MonoBehaviour
{

    public GameObject TextToChange;
    public string generatedName;

    public void GenerateRandomName()
    {
        PersonNameGenerator pGen = new RandomNameGeneratorLibrary.PersonNameGenerator();
        string name = pGen.GenerateRandomFirstAndLastName();
        Debug.Log("NAME GENERATED IS::" + name);
        SetGeneratedName(name);
        if (TextToChange != null)
        {
            ChangeText(name);
        }
    }

    public void GenerateRandomNameFemale()
    {
        PersonNameGenerator pGen = new RandomNameGeneratorLibrary.PersonNameGenerator();
        string name = pGen.GenerateRandomFemaleFirstAndLastName();
        Debug.Log("NAME GENERATED IS::" + name);
        SetGeneratedName(name);
        if (TextToChange != null)
        {
            ChangeText(name);
        }
    }

    public void GenerateRandomNameMale()
    {
        PersonNameGenerator pGen = new RandomNameGeneratorLibrary.PersonNameGenerator();
        string name = pGen.GenerateRandomMaleFirstAndLastName();
        Debug.Log("NAME GENERATED IS::" + name);
        SetGeneratedName(name);
        if (TextToChange != null)
        {
            ChangeText(name);
        }
    }

    public void GenerateRandomPlaceName()
    {
        PlaceNameGenerator pGen = new RandomNameGeneratorLibrary.PlaceNameGenerator();
        string name = pGen.GenerateRandomPlaceName();
        Debug.Log("NAME GENERATED IS::" + name);
        SetGeneratedName(name);
        if (TextToChange != null)
        {
            ChangeText(name);
        }
    }
    void ChangeText(string newText)
    {
        TextToChange.GetComponentInChildren<Text>().text = newText;
    }

    void SetGeneratedName(string name)
    {
        generatedName = name;
    }


}
