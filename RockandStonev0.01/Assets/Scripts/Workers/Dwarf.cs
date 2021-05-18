using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dwarf : MonoBehaviour
{

    public string subjectName;
    public string subjectStatus;
    public string subjectJob;

    public int invSize;

    public GameObject workLedger;
    public GameObject[] inventory;


    private void Start()
    {
        inventory = new GameObject[invSize];
    }


    public void Update()
    {
        
    }
}
