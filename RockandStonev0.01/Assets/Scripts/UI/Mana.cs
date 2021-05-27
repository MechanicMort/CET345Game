using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public float maxMana;
    public float CurrentMana;


    private void Update()
    {
        maxMana = GameObject.FindGameObjectsWithTag("Altar").Length * 100;
        this.GetComponent<Image>().fillAmount =  CurrentMana/ maxMana;
    }
}
