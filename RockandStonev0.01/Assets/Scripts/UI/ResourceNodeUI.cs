using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceNodeUI : MonoBehaviour
{
    public Image progressBar;

    public Dropdown dwarf1Selection;
    public Dropdown dwarf2Selection;
    public Dropdown dwarf3Selection;

    public GameObject resourceNodeSelected;

    public GameManager gameManager;


    public List<GameObject> dwarves;
    public List<string> dwarvesNames;

    private void OnEnable()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();


        dwarf1Selection.ClearOptions();
        dwarf2Selection.ClearOptions();
        dwarf3Selection.ClearOptions();
        List<string> none = new List<string>();

        if (resourceNodeSelected.GetComponent<ResourceNode>().dwarf1 != null)
        {
            none.Add(resourceNodeSelected.GetComponent<ResourceNode>().dwarf1.GetComponent<Dwarf>().subjectName);
            dwarf1Selection.AddOptions(none);
            none.Clear();
        }
        else
        {
            none.Add("None");
            dwarf1Selection.AddOptions(none);
            none.Clear();
        }


        if (resourceNodeSelected.GetComponent<ResourceNode>().dwarf2 != null)
        {
            none.Add(resourceNodeSelected.GetComponent<ResourceNode>().dwarf2.GetComponent<Dwarf>().subjectName);
            dwarf2Selection.AddOptions(none);
            none.Clear();
        }
        else
        {
            none.Add("None");
            dwarf2Selection.AddOptions(none);
            none.Clear();
        }

        if (resourceNodeSelected.GetComponent<ResourceNode>().dwarf3 != null)
        {
            none.Add(resourceNodeSelected.GetComponent<ResourceNode>().dwarf3.GetComponent<Dwarf>().subjectName);
            dwarf3Selection.AddOptions(none);
            none.Clear();
        }
        else
        {
            none.Add("None");
            dwarf3Selection.AddOptions(none);
            none.Clear();
        }

        /*
         * redo once other stuff is done
         * copy over to the final array only if they have the correct job
        for (int i = 0; i < dwarves.Count; i++)
        {
            if (dwarves[i].GetComponent<Dwarf>().subjectJob == "BlackSmith")
            {

            }
        }
        */
        dwarves.Clear();
        dwarvesNames.Clear();
        dwarves.AddRange(GameObject.FindGameObjectsWithTag("Dwarf"));


        for (int i = 0; i < dwarves.Count; i++)
        {
            if (dwarves[i].GetComponent<Dwarf>().hasJob == false && dwarves[i].GetComponent<Dwarf>().subjectJob == "Miner")
            {
                dwarvesNames.Add(dwarves[i].GetComponent<Dwarf>().subjectName);
            }
        }


        dwarf1Selection.AddOptions(dwarvesNames);
        dwarf2Selection.AddOptions(dwarvesNames);
        dwarf3Selection.AddOptions(dwarvesNames);
    }





    // Update is called once per frame
    void Update()
    {




        progressBar.fillAmount = resourceNodeSelected.GetComponent<ResourceNode>().workDone / 100;
        //dwarves
        if (GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text) != null)
        {
            if (GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text).GetComponent<Dwarf>().hasJob == false)
            {
                resourceNodeSelected.GetComponent<ResourceNode>().dwarf1 = GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text);
            }
        }
        else if (dwarf1Selection.GetComponentInChildren<Text>().text == "Remove Dwarf")
        {
            resourceNodeSelected.GetComponent<WorkShop>().dwarf1.GetComponent<Dwarf>().hasJob = false;
            resourceNodeSelected.GetComponent<WorkShop>().dwarf1.GetComponent<Dwarf>().workPlace = new Vector3(0, 0, 0);
            resourceNodeSelected.GetComponent<WorkShop>().dwarf1 = null;
        }


        if (GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text) != null)
        {
            if (GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text).GetComponent<Dwarf>().hasJob == false)
            {
                resourceNodeSelected.GetComponent<ResourceNode>().dwarf2 = GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text);
            }
        }
        else if (dwarf2Selection.GetComponentInChildren<Text>().text == "Remove Dwarf")
        {
            resourceNodeSelected.GetComponent<WorkShop>().dwarf2.GetComponent<Dwarf>().hasJob = false;
            resourceNodeSelected.GetComponent<WorkShop>().dwarf2.GetComponent<Dwarf>().workPlace = new Vector3(0, 0, 0);
            resourceNodeSelected.GetComponent<WorkShop>().dwarf2 = null;
        }

        if (GameObject.Find(dwarf3Selection.GetComponentInChildren<Text>().text) != null)
        {
            if (GameObject.Find(dwarf3Selection.GetComponentInChildren<Text>().text).GetComponent<Dwarf>().hasJob == false)
            {
                resourceNodeSelected.GetComponent<ResourceNode>().dwarf3 = GameObject.Find(dwarf3Selection.GetComponentInChildren<Text>().text);
            }
        }
        else if (dwarf3Selection.GetComponentInChildren<Text>().text == "Remove Dwarf")
        {
            resourceNodeSelected.GetComponent<WorkShop>().dwarf3.GetComponent<Dwarf>().hasJob = false;
            resourceNodeSelected.GetComponent<WorkShop>().dwarf3.GetComponent<Dwarf>().workPlace = new Vector3(0, 0, 0);
            resourceNodeSelected.GetComponent<WorkShop>().dwarf3 = null;
        }
    }
}
