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
    public float foodWorth;
    public float wheatWorth;


    private void Update()
    {
        totalWorth = stoneWorth + slabWorth + woodWorth + clayWorth + foodWorth + wheatWorth;
    }
}
