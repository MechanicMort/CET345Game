using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkShopUI : MonoBehaviour
{

    public Image progressBar;

    public Dropdown dwarf1Selection;
    public Dropdown dwarf2Selection;
    public Dropdown dwarf3Selection;
    public Dropdown recipeSelection;

    public GameObject workShopSelected;
    public GameManager gameManager;

    public Recipe[] recipesKnown;
    public List<string> recipeNames = new List<string>();

    public List<GameObject> dwarves;
    public List<string> dwarvesNames;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        recipesKnown = gameManager.getRecipes();

        for (int i = 0; i < recipesKnown.Length; i++)
        {
            recipeNames.Add(recipesKnown[i].recipeName);
        }

        dwarf1Selection.ClearOptions();
        dwarf2Selection.ClearOptions();
        dwarf3Selection.ClearOptions();
        List<string> none = new List<string>();

        if (workShopSelected.GetComponent<WorkShop>().dwarf1 != null)
        {
            none.Add(workShopSelected.GetComponent<WorkShop>().dwarf1.GetComponent<Dwarf>().subjectName);
            dwarf1Selection.AddOptions(none);
            none.Clear();
        }
        else
        {
            none.Add("None");
            dwarf1Selection.AddOptions(none);
            none.Clear();
        }


        if (workShopSelected.GetComponent<WorkShop>().dwarf2 != null)
        {
            none.Add(workShopSelected.GetComponent<WorkShop>().dwarf2.GetComponent<Dwarf>().subjectName);
            dwarf2Selection.AddOptions(none);
            none.Clear();
        }
        else
        {
            none.Add("None");
            dwarf2Selection.AddOptions(none);
            none.Clear();
        }

        if (workShopSelected.GetComponent<WorkShop>().dwarf3 != null)
        {
            none.Add(workShopSelected.GetComponent<WorkShop>().dwarf3.GetComponent<Dwarf>().subjectName);
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
        for (int i = 0; i < dwarves.Count; i++)
        {
            if (dwarves[i].GetComponent<Dwarf>().subjectJob == "BlackSmith")
            {

            }
        }
        */
        dwarves.AddRange(GameObject.FindGameObjectsWithTag("Dwarf"));


        for (int i = 0; i < dwarves.Count; i++)
        {
            dwarvesNames.Add(dwarves[i].GetComponent<Dwarf>().subjectName);
        }


        dwarf1Selection.AddOptions(dwarvesNames);
        dwarf2Selection.AddOptions(dwarvesNames);
        dwarf3Selection.AddOptions(dwarvesNames);


        recipeSelection.AddOptions(recipeNames);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text) != null)
        {
            if (GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text).GetComponent<Dwarf>().hasJob == false)
            {
                workShopSelected.GetComponent<WorkShop>().dwarf1 = GameObject.Find(dwarf1Selection.GetComponentInChildren<Text>().text);
            }
        }


        if (GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text) != null)
        {
            if (GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text).GetComponent<Dwarf>().hasJob == false)
            {
                workShopSelected.GetComponent<WorkShop>().dwarf2 = GameObject.Find(dwarf2Selection.GetComponentInChildren<Text>().text);
            }
        }

        if (GameObject.Find(dwarf3Selection.GetComponentInChildren<Text>().text) != null)
        {
            if (GameObject.Find(dwarf3Selection.GetComponentInChildren<Text>().text).GetComponent<Dwarf>().hasJob == false)
            {
                workShopSelected.GetComponent<WorkShop>().dwarf3 = GameObject.Find(dwarf3Selection.GetComponentInChildren<Text>().text);
            }
        }

        if (gameManager.getThisRecipe(recipeSelection.GetComponentInChildren<Text>().text))
        {
            workShopSelected.GetComponent<WorkShop>().workrecipe = gameManager.getThisRecipe(recipeSelection.GetComponentInChildren<Text>().text);
        }

    }
}
