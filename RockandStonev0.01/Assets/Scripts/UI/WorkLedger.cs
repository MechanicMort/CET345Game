using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkLedger : MonoBehaviour
{

    private GameObject[] subjectsDwarves = new GameObject[0];
    public GameObject dwarfLedger;
    public GameObject ledgerView;
    public GameObject Ledger;

    public Dictionary<string, int> jobDictionary = new Dictionary<string, int>();

    //update ledger every time it is opnened


    // Start is called before the first frame update
    void Start()
    {
        jobDictionary.Add("Hauling",0);
        jobDictionary.Add("BlackSmith",1);
        jobDictionary.Add("Farmer", 2);
        jobDictionary.Add("Miner", 3);
        subjectsDwarves = GameObject.FindGameObjectsWithTag("Dwarf");

        UpdateLedger();
        
    }


    private void OnEnable()
    {
        UpdateLedger();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ledgerView.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ledgerView.SetActive(true);
        }
    }


    public void UpdateLedger()
    {

        for (int i = 0; i < ledgerView.gameObject.transform.childCount; i++)
        {
            Destroy(ledgerView.gameObject.transform.GetChild(i).gameObject);
        }
        if (subjectsDwarves.Length > 0)
        {
            for (int i = 0; i < subjectsDwarves.Length; i++)
            {
                GameObject dwarfLedgerTemp;

                dwarfLedgerTemp = Instantiate(subjectsDwarves[i].GetComponent<Dwarf>().workLedger);
                dwarfLedgerTemp.transform.SetParent(ledgerView.transform, true);
                dwarfLedgerTemp.transform.GetChild(0).GetComponent<LedgerUpdate>().myDwarf = subjectsDwarves[i];

                dwarfLedgerTemp.transform.GetChild(0).GetComponent<Dropdown>().SetValueWithoutNotify(jobDictionary[subjectsDwarves[i].GetComponent<Dwarf>().subjectJob]);

                dwarfLedgerTemp.transform.GetChild(1).GetComponent<Text>().text = subjectsDwarves[i].GetComponent<Dwarf>().subjectName;
                dwarfLedgerTemp.transform.GetChild(2).GetComponent<Text>().text = "Status:" + subjectsDwarves[i].GetComponent<Dwarf>().subjectStatus;


            }

        }
      
    }
}
