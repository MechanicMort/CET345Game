using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTransfer : MonoBehaviour
{
    public GameObject attachedWorkStation;
    public GameObject workingDwarf;
    public bool isDwarfHere;
    void Start()
    {
        StartCoroutine(Work());
        attachedWorkStation = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject == workingDwarf)
        {
            isDwarfHere = true;

            attachedWorkStation.SendMessage("recieveWork", other.gameObject.GetComponent<Dwarf>().Work());
        }
    }
  

    private IEnumerator Work()
    {
        yield return new WaitForSeconds(0.1f);
        if (isDwarfHere)
        {

            attachedWorkStation.SendMessage("recieveWork", workingDwarf.gameObject.GetComponent<Dwarf>().Work());
        }
        StartCoroutine(Work());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject == workingDwarf)
        {
            isDwarfHere = false;
        }
    }


}
