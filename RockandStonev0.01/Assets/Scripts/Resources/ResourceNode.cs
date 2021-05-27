using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{

    public float workNeeded;
    public float workDone;

    public Vector3 workPos;

    public GameObject outPut;


    private void Update()
    {
        if (workDone >= workNeeded)
        {
            Instantiate(outPut);
            workDone = 0;
        }
    }

    public void RecieveWork(float workAdded)
    {
        workDone += workAdded;
    }
}
