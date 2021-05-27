using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{

    public float workNeeded;
    public float workDone;

    public GameObject workPos1;
    public GameObject workPos2;
    public GameObject workPos3;


    public GameObject dwarf1;
    public GameObject dwarf2;
    public GameObject dwarf3;

    public GameObject outPut;
    public GameObject outputPos;


    private void Update()
    {
        if (workDone >= workNeeded)
        {
            GameObject temp = Instantiate(outPut);
            temp.transform.position = outputPos.transform.position;

            workDone = 0;
        }


        if (dwarf1 != null)
        {
            dwarf1.GetComponent<Dwarf>().hasJob = true;
            dwarf1.GetComponent<Dwarf>().workPlace = workPos1.transform.position;
            workPos1.GetComponent<WorkTransfer>().workingDwarf = dwarf1;
        }
        if (dwarf2 != null)
        {
            dwarf2.GetComponent<Dwarf>().hasJob = true;
            dwarf2.GetComponent<Dwarf>().workPlace = workPos2.transform.position;
            workPos2.GetComponent<WorkTransfer>().workingDwarf = dwarf2;
        }
        if (dwarf3 != null)
        {
            dwarf3.GetComponent<Dwarf>().hasJob = true;
            dwarf3.GetComponent<Dwarf>().workPlace = workPos3.transform.position;
            workPos3.GetComponent<WorkTransfer>().workingDwarf = dwarf3;
        }
    }

    public void RecieveWork(float workAdded)
    {
        workDone += workAdded;
    }
}
