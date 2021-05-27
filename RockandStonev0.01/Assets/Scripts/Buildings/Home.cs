using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public float spaces;
    private void Update()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Dwarf").Length; i++)
        {
            if (spaces > 0)
            {
                if (GameObject.FindGameObjectsWithTag("Dwarf")[i].GetComponent<Dwarf>().hasHome == false)
                {
                    GameObject.FindGameObjectsWithTag("Dwarf")[i].GetComponent<Dwarf>().hasHome = true;
                    GameObject.FindGameObjectsWithTag("Dwarf")[i].GetComponent<Dwarf>().homeLocation = transform.position;
                    spaces -= 1;
                }
            }
            else
            {
                break;
            }
        }
    }
}
