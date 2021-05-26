using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkShop : MonoBehaviour
{

    public GameObject workShopCanvas;

    public Recipe workrecipe;

    public float input1Amount;
    public string input1Name;

    public float input2Amount;
    public string input2Name;


    public float input3Amount;
    public string input3Name;

    public GameObject dwarf1;
    public GameObject workpos1;

    public GameObject dwarf2;
    public GameObject workpos2;

    public GameObject dwarf3;
    public GameObject workpos3;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dwarf1 != null)
        {
            dwarf1.GetComponent<Dwarf>().hasJob = true;
            dwarf1.GetComponent<Dwarf>().workPlace = workpos1.transform.position;
        }
        if (dwarf2 != null)
        {
            dwarf2.GetComponent<Dwarf>().hasJob = true;
            dwarf2.GetComponent<Dwarf>().workPlace = workpos2.transform.position;
        }
        if (dwarf3 != null)
        {
            dwarf3.GetComponent<Dwarf>().hasJob = true;
            dwarf3.GetComponent<Dwarf>().workPlace = workpos3.transform.position;
        }
        
    
    }

    public void recieveWork()
    {

    }


}
