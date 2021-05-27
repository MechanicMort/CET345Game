using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkShop : MonoBehaviour
{

    public GameObject workShopCanvas;
    public GameObject dropOffPos;
    public GameObject outPutPos;

    public Recipe workrecipe;
    public Camera playerCam;

    public bool hasResources;

    public float workAmount;
    public float workDone;

    public float stoneNeeded;
    public float stoneStored;

    public float woodNeeded;
    public float woodStored;

    public float clayneeded;
    public float clayStored;

    public float slabsNeeded;
    public float slabsStored;

    public float wheatNeeded;
    public float wheatStored;

    public float foodNeeded;
    public float foodStored;

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

    private void CheckResources()
    {
        if (stoneNeeded <= stoneStored && woodNeeded <= woodStored && clayneeded <= clayStored && slabsNeeded <= slabsStored)
        {
            hasResources = true;
        }
        else
        {
            hasResources = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckResources();
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

            stoneNeeded = workrecipe.stoneNeeded;

            woodNeeded = workrecipe.woodNeeded;
           
            clayneeded = workrecipe.clayNeeded;
        }

        if (dwarf1 != null)
        {
            dwarf1.GetComponent<Dwarf>().hasJob = true;
            dwarf1.GetComponent<Dwarf>().workPlace = workpos1.transform.position;
            workpos1.GetComponent<WorkTransfer>().workingDwarf = dwarf1;
        }
        if (dwarf2 != null)
        {
            dwarf2.GetComponent<Dwarf>().hasJob = true;
            dwarf2.GetComponent<Dwarf>().workPlace = workpos2.transform.position;
            workpos2.GetComponent<WorkTransfer>().workingDwarf = dwarf2;
        }
        if (dwarf3 != null)
        {
            dwarf3.GetComponent<Dwarf>().hasJob = true;
            dwarf3.GetComponent<Dwarf>().workPlace = workpos3.transform.position;
            workpos3.GetComponent<WorkTransfer>().workingDwarf = dwarf3;
        }
        
    
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ResourceChunk")
        {

                stoneStored += collision.gameObject.GetComponent<ResourceChunk>().stoneWorth;
                woodStored += collision.gameObject.GetComponent<ResourceChunk>().woodWorth;
                clayStored += collision.gameObject.GetComponent<ResourceChunk>().clayWorth;
                slabsStored += collision.gameObject.GetComponent<ResourceChunk>().slabWorth;
                foodStored += collision.gameObject.GetComponent<ResourceChunk>().foodWorth;
                wheatStored += collision.gameObject.GetComponent<ResourceChunk>().wheatWorth;
                Destroy(collision.gameObject);
        }
    }

    public Vector3 DropOff()
    {
        return dropOffPos.transform.position;
    }

    public void recieveWork(float recievedWork)
    {
        print(recievedWork);
        if (hasResources)
        {
            workDone += recievedWork;
        }
        if (workDone >= workAmount && hasResources && outPut != null)
        {
            GameObject temp = Instantiate(outPut);
            temp.transform.position = outPutPos.transform.position;

            workDone = 0;
        }
    }


}
