using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Altar : MonoBehaviour
{
    public GameObject resourceNodeCanvas;
    public Camera playerCam;
    public float workNeeded;
    public float workDone;

    public GameObject workPos1;
    public GameObject workPos2;
    public GameObject workPos3;


    public GameObject dwarf1;
    public GameObject dwarf2;
    public GameObject dwarf3;

    public Mana mana;
    public float manaAmount;



    private void Start()
    {
        mana = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mana>();
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        resourceNodeCanvas = GameObject.FindGameObjectWithTag("ResourceNodeCanvas").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.name == this.gameObject.transform.name)
                {
                    resourceNodeCanvas.GetComponent<ResourceNodeUI>().resourceNodeSelected = this.gameObject;
                    resourceNodeCanvas.SetActive(true);
                }

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {

            resourceNodeCanvas.SetActive(false);
        }

        if (workDone >= workNeeded)
        {
            mana.CurrentMana += manaAmount;
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

    public void recieveWork(float workAdded)
    {
        workDone += workAdded;
    }
}
