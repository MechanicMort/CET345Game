using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedgerUpdate : MonoBehaviour
{
    public GameObject workLedger;
    public GameObject myDwarf;

    public void Start()
    {
        workLedger = GameObject.FindGameObjectWithTag("WorkLedger");
    }
    public void UpdateLedger()
    {
        myDwarf.GetComponent<Dwarf>().subjectJob = transform.GetChild(0).GetComponent<Text>().text;
        if (workLedger.gameObject.activeInHierarchy)
        {
            workLedger.GetComponent<WorkLedger>().UpdateLedger();
        }
    }
}
