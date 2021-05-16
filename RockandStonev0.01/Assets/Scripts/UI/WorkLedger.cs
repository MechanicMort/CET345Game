using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkLedger : MonoBehaviour
{

    private GameObject[] subjectsDwarves;
    public GameObject dwarfLedger;
    public GameObject ledgerView;

    public Dictionary<string, int> jobDictionary = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        jobDictionary.Add("Hauling",0);
        jobDictionary.Add("BlackSmith",1);
        jobDictionary.Add("Farmer", 2);
        subjectsDwarves = GameObject.FindGameObjectsWithTag("Dwarf");

        UpdateLedger();
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void UpdateLedger()
    {
        print("Updating");

        for (int i = 0; i < ledgerView.gameObject.transform.childCount; i++)
        {
            Destroy(ledgerView.gameObject.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < subjectsDwarves.Length; i++)
        {
            GameObject dwarfLedgerTemp;

            dwarfLedgerTemp = Instantiate(subjectsDwarves[i].GetComponent<Dwarf>().workLedger);
            dwarfLedgerTemp.transform.SetParent(ledgerView.transform, true);
            dwarfLedgerTemp.transform.GetChild(0).GetComponent<LedgerUpdate>().myDwarf = subjectsDwarves[i];

            print(subjectsDwarves[i].GetComponent<Dwarf>().subjectJob);

            dwarfLedgerTemp.transform.GetChild(0).GetComponent<Dropdown>().SetValueWithoutNotify ( jobDictionary[subjectsDwarves[i].GetComponent<Dwarf>().subjectJob]);

            dwarfLedgerTemp.transform.GetChild(1).GetComponent<Text>().text = subjectsDwarves[i].GetComponent<Dwarf>().subjectName;
            dwarfLedgerTemp.transform.GetChild(2).GetComponent<Text>().text = subjectsDwarves[i].GetComponent<Dwarf>().subjectStatus;


        }
    }
}
