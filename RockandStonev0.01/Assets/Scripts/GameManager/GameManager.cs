using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float researchTier;
    public GameObject[] recipes;
    public ArrayList Resources;
    // Start is called before the first frame update
    void Start()
    {
        ///Stone
        ///wood
        ///wheat
        ///clay
        Resources.Add(10);
        Resources.Add(10);
        Resources.Add(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
