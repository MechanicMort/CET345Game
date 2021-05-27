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
    public bool isStorageFull;

    public GameObject DropOffPoint;
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


                Destroy(collision.gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        currentStored = stoneStored + woodStored + clayStored + slabsStored;
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
