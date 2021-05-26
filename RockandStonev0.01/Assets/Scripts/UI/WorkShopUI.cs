using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkShopUI : MonoBehaviour
{

    public Image progressBar;

    public Dropdown dwarfSelector;

    public List<GameObject> dwarves;
    public List<string> dwarvesNames;

    // Start is called before the first frame update
    void Start()
    {

        dwarfSelector.ClearOptions();
        List<string> none = new List<string>();
        none.Add("None");
        dwarfSelector.AddOptions(none);

        dwarves.AddRange(GameObject.FindGameObjectsWithTag("Dwarf"));

        for (int i = 0; i < dwarves.Count; i++)
        {
            dwarvesNames.Add(dwarves[i].GetComponent<Dwarf>().subjectName);
        }


        dwarfSelector.AddOptions(dwarvesNames);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
