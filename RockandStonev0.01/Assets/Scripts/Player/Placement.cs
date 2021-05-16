using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placement : MonoBehaviour
{

    public GameObject PlacementTemp;
    public GameObject Place;
    GameObject temp;
    public Camera playerCam;
    private int lM;
    // Start is called before the first frame update
    void Start()
    {
        lM = 1 << 6;
        temp = Instantiate(PlacementTemp);
      
    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;

        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            temp.transform.position = hit.point;
            Transform objectHit = hit.transform;
            if (objectHit.tag == "Temp" || objectHit.tag =="Building" )
            {
                //
            }
            else
            {

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(Place, hit.point, hit.transform.rotation, transform.parent = null);
                }

            }
        }
           
            // Do something with the object that was hit by the raycast.
        }
    }

