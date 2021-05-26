using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public GameObject finishedBuilding;
    public GameManager gameManager;

    public float workNeeded;

    public float stoneNeeded;

    public float woodNeeded;

    public float clayNeeded;

    public float totalAmount;



    // Start is called before the first frame update
    void Start()
    {
        totalAmount = clayNeeded + stoneNeeded + woodNeeded;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();



    }

    private void Update()
    {
        totalAmount = clayNeeded + stoneNeeded + woodNeeded;
        if (totalAmount <= 0)
        {
            Instantiate(finishedBuilding,transform.position,transform.rotation,null);
            Destroy(this.gameObject);
        }
    }


    //very bad code look back if hav time
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ResourceChunk")
        {
            //stone delivery
            if (collision.gameObject.GetComponent<ResourceChunk>().stoneWorth > stoneNeeded)
            {
                stoneNeeded = 0;
                collision.gameObject.GetComponent<ResourceChunk>().stoneWorth -= stoneNeeded;
            }
            else
            {
                stoneNeeded -= collision.gameObject.GetComponent<ResourceChunk>().stoneWorth;
                collision.gameObject.GetComponent<ResourceChunk>().stoneWorth -= stoneNeeded;
            }
            //wood Delivery
            if (collision.gameObject.GetComponent<ResourceChunk>().woodWorth > woodNeeded)
            {
                woodNeeded = 0;
                collision.gameObject.GetComponent<ResourceChunk>().woodWorth -= woodNeeded;
            }
            else
            {
                woodNeeded -= collision.gameObject.GetComponent<ResourceChunk>().woodWorth;
                collision.gameObject.GetComponent<ResourceChunk>().woodWorth -= woodNeeded;
            }
            //clay delivery
            if (collision.gameObject.GetComponent<ResourceChunk>().clayWorth > clayNeeded)
            {
                clayNeeded = 0;
                collision.gameObject.GetComponent<ResourceChunk>().clayWorth -= clayNeeded;
            }
            else
            {
                clayNeeded -= collision.gameObject.GetComponent<ResourceChunk>().clayWorth;
                collision.gameObject.GetComponent<ResourceChunk>().clayWorth -= clayNeeded;
            }
        }
    }

}
