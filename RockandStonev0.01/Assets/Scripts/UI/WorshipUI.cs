using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorshipUI : MonoBehaviour
{
    public Dropdown dwarf1Selection;
    public Dropdown dwarf2Selection;

    public GameObject altarSelected;

    public GameManager gameManager;


    public List<GameObject> dwarves;
    public List<string> dwarvesNames;

    private void OnEnable()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();


        dwarf1Selection.ClearOptions();
        dwarf2Selection.ClearOptions();
        List<string> none = new List<string>();

        if (altarSelected.GetComponent<Altar>().dwarf1 != null)
        {
            none.Add(altarSelected.GetComponent<Altar>().dwarf1.GetComponent<Dwarf>().subjectName);
            dwarf1Selection.AddOptions(none);
            none.Clear();
        }
        else
        {
            none.Add("None");
            dwarf1Selection.AddOptions(none);
            none.Clear();
        }


        if (altarSelected.GetComponent<Altar>().dwarf2 != null)
        {
            none.Add(altarSelected.GetComponent<Altar>().dwarf2.GetComponent<Dwarf>().subjectName);
            dwarf2Selection.AddOptions(none);
            none.Clear();
        }
        else
        {
            none.Add("None");
            dwarf2Selection.AddOptions(none);
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
            if (dwarves[i].GetComponent<Dwarf>().hasJob == false && dwarves[i].GetComponent<Dwarf>().subjectJob == "Worshiper")
            {
                dwarvesNames.Add(dwarves[i].GetComponent<Dwarf>().subjectName);
            }
        }


        dwarf1Selection.AddOptions(dwarvesNames);
        dwarf2Selection.AddOptions(dwarvesNames);
    }





    // Update is called once per frame
    void Update()
    {
        //dwarves
        if (GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text) != null)
        {
            if (GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text).GetComponent<Dwarf>().hasJob == false)
            {
                altarSelected.GetComponent<Altar>().dwarf1 = GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text);
            }
        }
        else if (dwarf1Selection.GetComponentInChildren<Text>().text == "Remove Dwarf")
        {
            altarSelected.GetComponent<Altar>().dwarf1.GetComponent<Dwarf>().hasJob = false;
            altarSelected.GetComponent<Altar>().dwarf1.GetComponent<Dwarf>().workPlace = new Vector3(0, 0, 0);
            altarSelected.GetComponent<Altar>().dwarf1 = null;
        }


        if (GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text) != null)
        {
            if (GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text).GetComponent<Dwarf>().hasJob == false)
            {
                altarSelected.GetComponent<Altar>().dwarf2 = GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text);
            }
        }
        else if (dwarf2Selection.GetComponentInChildren<Text>().text == "Remove Dwarf")
        {
            altarSelected.GetComponent<Altar>().dwarf2.GetComponent<Dwarf>().hasJob = false;
            altarSelected.GetComponent<Altar>().dwarf2.GetComponent<Dwarf>().workPlace = new Vector3(0, 0, 0);
            altarSelected.GetComponent<Altar>().dwarf2 = null;
        }
    }
}
