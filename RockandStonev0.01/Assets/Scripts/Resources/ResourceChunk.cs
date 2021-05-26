using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceChunk : MonoBehaviour
{
    public float totalWorth;
    public float stoneWorth;
    public float slabWorth;
    public float woodWorth;
    public float clayWorth;


    private void Update()
    {
        totalWorth = stoneWorth + slabWorth + woodWorth + clayWorth;
    }
}
