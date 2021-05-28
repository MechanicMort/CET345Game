using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using WUG.BehaviorTreeVisualizer;

public class NonPlayerCharacter : MonoBehaviour, IBehaviorTree
{
    private Coroutine m_BehaviorTreeRoutine;
    private YieldInstruction m_WaitTime = new WaitForSeconds(.1f);
    public NodeBase BehaviorTree { get; set; }

    private string job;

    private Vector3 deliveryPos;

    private NavMeshAgent navAgent;

    private GameObject[] findingChunks;
    private GameObject[] storageLocations;

    public float[] currentOrder = new float[6];
    public float orderTotal;


    public bool hasDelivery = false;


    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(AIRunTime());
    }

    private void Update()
    {
        job = GetComponent<Dwarf>().subjectJob;

        orderTotal = 0;
        for (int i = 0; i < currentOrder.Length; i++)
        {
            orderTotal += currentOrder[i];
        }

        if (orderTotal <= 0)
        {
            hasDelivery = false;
        }

    }


    private IEnumerator AIRunTime()
    {
        yield return new WaitForSeconds(0.1f);
        AI();
        StartCoroutine(AIRunTime());

    }

    private bool BuildingSite()
    {
        return true;
    }

    private bool NeedDelivery()
    {
        if (hasDelivery == true)
        {
            return false;
        }
        else
        {
            print("Delivery Created");
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("WorkShop").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("WorkShop")[i].GetComponent<WorkShop>().hasResources == false)
                {
                    currentOrder = GameObject.FindGameObjectsWithTag("WorkShop")[i].GetComponent<WorkShop>().createOrder();
                    deliveryPos = GameObject.FindGameObjectsWithTag("WorkShop")[i].transform.position;
                    return true;       
                }
            }
            print("Returning false");
            return false;
        }    
    }

    private Vector3 FindMatsFromStorage()
    {
        print("GettingMats");
        Vector3 storagePos = new Vector3(0,0,0);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("StorageBuilding").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("StorageBuilding")[i].GetComponent<Storage>().hasSupplies(currentOrder))
            {
                storagePos = GameObject.FindGameObjectsWithTag("StorageBuilding")[i].transform.position;
                return storagePos;
            }
        }
        return storagePos;
    }

    private void AI()
    {
        if (GetComponent<Dwarf>().Hunger > 30)
        {

            //&& GameObject.FindGameObjectsWithTag("ResourceChunk").Length > 0
            //add if for not hungry
            if (job == "Hauling")
            {
                //find item if space in inventory
                if (!GetComponent<Dwarf>().isInvFull)
                {
                    if (NeedDelivery())
                    {
                        navAgent.destination = FindMatsFromStorage();
                    }
                    else if (hasDelivery == true)
                    {
                        print("stuck here");
                        navAgent.destination = deliveryPos;
                    }
                    else if (LookForClosestItemToHaul() != new Vector3(0,0,0))
                    {
                        print("stuck here insteasd");
                        navAgent.destination = LookForClosestItemToHaul();
                    }
                    else
                    {
                        print("Heading Home");
                        goHome();
                    }
                }
                else if(hasDelivery == false)
                {
                    navAgent.destination = LookForSpaceToStore();
                }
                else if(hasDelivery == true)
                {
                    navAgent.destination = deliveryPos;
                }
            }
            else if (job == "BlackSmith" || job == "Worshiper" || job == "Gatherer")
            {
                if (GetComponent<Dwarf>().hasJob)
                {
                    navAgent.destination = GoToJob();
                }
                else
                {
                    navAgent.destination = goHome();
                }
            }
        }

    }


    private Vector3 lookForFood()
    {
        Vector3 jobPos = new Vector3(0, 0, 0);
        jobPos = GetComponent<Dwarf>().workPlace;
        return jobPos;
    }

    private Vector3 goHome()
    {
        Vector3 home = new Vector3(0, 0, 0);
        home = GetComponent<Dwarf>().homeLocation;
        return home;
    }
    private Vector3 GoToJob()
    {
        Vector3 jobPos = new Vector3(0,0,0);
        jobPos = GetComponent<Dwarf>().workPlace;
        return jobPos;
    }

    private Vector3 LookForSpaceToStore()
    {
        storageLocations = GameObject.FindGameObjectsWithTag("StorageBuilding");
        for (int i = 0; i < storageLocations.Length; i++)
        {
            if (storageLocations[i].GetComponent<Storage>().isStorageFull == true)
            {
                storageLocations[i] = null;
            }
        }
        float closeness = Mathf.Infinity;
        Vector3 closestPos = new Vector3(0, 0, 0);
        for (int i = 0; i < storageLocations.Length; i++)
        {
            if (storageLocations[i] != null)
            {
                if (Vector3.Distance(storageLocations[i].transform.position, transform.position) < closeness)
                {
                    closeness = Vector3.Distance(storageLocations[i].transform.position, transform.position);
                    closestPos = storageLocations[i].GetComponent<Storage>().DropOff();
                }
            }
           
        }

        return closestPos;
    }

    private Vector3 LookForClosestItemToHaul()
    {
        findingChunks = GameObject.FindGameObjectsWithTag("ResourceChunk");
        float closeness = Mathf.Infinity;
        Vector3 closestPos = new Vector3(0,0,0);
        for (int i = 0; i < findingChunks.Length; i++)
        {
            if (Vector3.Distance(findingChunks[i].transform.position , transform.position) < closeness)
            {
                closeness = Vector3.Distance(findingChunks[i].transform.position, transform.position);
                closestPos = findingChunks[i].transform.position;
            }
        }

        return closestPos;
    }

    private void GenerateBehaviorTree()
    {
        //tree for free subject
        //selector (control subject
                //selector (haul item
                    //ishaul(returns false if there are objects to haul also sets item to haul
                    //sequence(look for item needed to haul
                        //inverter 
                            //areitemsnearby picks up item if near sets waypoint to next item needed or delivery place if inventory full
                        //setnext waypoint
                    //sequencer(navigate
                        //navigate





            //selector(subject job farmer
                    //isFarm(returns false if there are objects to haul also sets item to haul
                    //sequence(look for item needed to haul
                        //inverter 
                            //areitemsnearby picks up item if near sets waypoint to next item needed or delivery place if inventory full
                        //setnext waypoint
                    //sequencer(navigate
                        //navigate
            
        /*
        BehaviorTree = new Selector("Control NPC",
                            new Sequence("Pickup Item",
                                new IsNavigationActivityTypeOf(NavigationActivity.PickupItem),
                                new Selector("Look for or move to items",
                                    new Sequence("Look for items",
                                        new Inverter("Inverter",
                                            new AreItemsNearBy(5f)),
                                        new SetNavigationActivityTo(NavigationActivity.Waypoint)),
                                    new Sequence("Navigate to Item",
                                        new NavigateToDestination()))),
                            new Sequence("Move to Waypoint",
                                new IsNavigationActivityTypeOf(NavigationActivity.Waypoint),
                                new NavigateToDestination(),
                                new Timer(2f,
                                    new SetNavigationActivityTo(NavigationActivity.PickupItem))));
        */
    }

    private IEnumerator RunBehaviorTree()
    {
        while (enabled)
        {
            if (BehaviorTree == null)
            {
                $"{this.GetType().Name} is missing Behavior Tree. Did you set the BehaviorTree property?".BTDebugLog();
                continue;
            }

            (BehaviorTree as Node).Run();

            yield return m_WaitTime;
        }
    }

    private void OnDestroy()
    {
        if (m_BehaviorTreeRoutine != null)
        {
            StopCoroutine(m_BehaviorTreeRoutine);
        }
    }
}
