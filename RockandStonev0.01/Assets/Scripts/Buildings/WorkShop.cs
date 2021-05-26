using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkShop : MonoBehaviour
{

    public GameObject workShopCanvas;

    public Recipe workrecipe;
    public Camera playerCam;

    public float workAmount;
    public float workDone;

    public float input1Amount;
    public string input1Name;

    public float input2Amount;
    public string input2Name;


    public float input3Amount;
    public string input3Name;

    public GameObject outPut;

    public GameObject dwarf1;
    public GameObject workpos1;

    public GameObject dwarf2;
    public GameObject workpos2;

    public GameObject dwarf3;
    public GameObject workpos3;



    // Start is called before the first frame update
    void Start()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        workShopCanvas = GameObject.FindGameObjectWithTag("WorkShopCanvas").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.name == this.gameObject.transform.name )
                {
                    workShopCanvas.GetComponent<WorkShopUI>().workShopSelected = this.gameObject;
                    workShopCanvas.SetActive(true);


                }
          
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {

            workShopCanvas.SetActive(false);
        }




        if (workrecipe != null)
        {
            outPut = workrecipe.outPut;

            workAmount = workrecipe.workNeeded;

            input1Name = workrecipe.resource1;
            input1Amount = workrecipe.resource1Ammount;
            
            input2Name = workrecipe.resource2;
            input2Amount = workrecipe.resource2Ammount;
           
            input3Name = workrecipe.resource3;
            input3Amount = workrecipe.resource3Ammount;
        }

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
