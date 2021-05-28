using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxStorage;
    public float currentStored;
    
    public float stoneStored;
    public float slabsStored;

    public float woodStored;
    public float clayStored;
    public float wheatStored;
    public float foodStored;
    public bool isStorageFull;

    public GameObject DropOffPoint;
    public GameObject packagedGoods;


    void Start()
    {
        stoneStored += 10;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //add method to store
        if (collision.transform.tag == "ResourceChunk")
        {
            if (currentStored + collision.gameObject.GetComponent<ResourceChunk>().totalWorth <= maxStorage)
            {
                stoneStored += collision.gameObject.GetComponent<ResourceChunk>().stoneWorth;
                woodStored += collision.gameObject.GetComponent<ResourceChunk>().woodWorth;
                clayStored += collision.gameObject.GetComponent<ResourceChunk>().clayWorth;
                slabsStored += collision.gameObject.GetComponent<ResourceChunk>().slabWorth;

                wheatStored += collision.gameObject.GetComponent<ResourceChunk>().wheatWorth;
                foodStored += collision.gameObject.GetComponent<ResourceChunk>().foodWorth;


                Destroy(collision.gameObject);
            }
        }
        else if (collision.transform.tag == "Dwarf" && collision.gameObject.GetComponent<NonPlayerCharacter>().hasDelivery == false)
        {
            collision.gameObject.GetComponent<NonPlayerCharacter>().hasDelivery = true;
            GameObject temp = Instantiate(packagedGoods);

            for (int i = 0; i < collision.gameObject.GetComponent<NonPlayerCharacter>().currentOrder.Length; i++)
            {
                if (collision.gameObject.GetComponent<NonPlayerCharacter>().currentOrder[i] >= 1)
                {
                    if (i == 0 && stoneStored >= 10)
                    {
                        packagedGoods.GetComponent<ResourceChunk>().stoneWorth = 10;
                        stoneStored -= 10;
                    }
                    else if (i == 1 && woodStored >= 10)
                    {
                        packagedGoods.GetComponent<ResourceChunk>().woodWorth = 10;
                        woodStored -= 10;
                    }
                    else if (i == 2 && clayStored >= 10)
                    {
                        packagedGoods.GetComponent<ResourceChunk>().clayWorth = 10;
                        clayStored -= 10;
                    }
                    else if (i == 3 && slabsStored >= 10)
                    {
                        packagedGoods.GetComponent<ResourceChunk>().slabWorth = 10;
                        slabsStored -= 10;
                    }
                    else if (i == 4 && wheatStored >= 10)
                    {
                        packagedGoods.GetComponent<ResourceChunk>().wheatWorth = 10;
                        wheatStored -= 10;
                    }
                    else if (i == 5 && foodStored >= 10)
                    {
                        packagedGoods.GetComponent<ResourceChunk>().foodWorth = 10;
                        foodStored -= 10;
                    }
                }
            }
            temp.transform.position = collision.transform.position;
            for (int i = 0; i < collision.gameObject.GetComponent<Dwarf>().inventory.Length; i++)
            {
                if (collision.gameObject.GetComponent<Dwarf>().inventory[i]==null)
                {
                    collision.gameObject.GetComponent<Dwarf>().inventory[i] = temp;
                }

            }


        }

    }

    public bool hasSupplies(float[] order)
    {

        if (order[0] != 0 && order[0] <= stoneStored)
        {
            return true;
        }
        if (order[1] != 0 && order[1] <= woodStored)
        {
            return true;
        }
        if (order[2] != 0 && order[2] <= clayStored)
        {
            return true;
        }
        if (order[3] != 0 && order[3] <= slabsStored)
        {
            return true;
        }
        if (order[4] != 0 && order[4] <= wheatStored)
        {
            return true;
        }
        if (order[5] != 0 && order[5] <= foodStored)
        {
            return true;
        }
        return false;
    }

    public Vector3 DropOff()
    {
        return DropOffPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentStored = stoneStored + woodStored + clayStored + slabsStored + foodStored + wheatStored;
        if (currentStored >= maxStorage)
        {
            isStorageFull = true;
        }
        else
        {
            isStorageFull = false;
        }
    }
}
